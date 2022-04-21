using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ListenerInterface;
using TrackingComponents;

namespace Task02._3
{
    public class Logger
    {
        public Logger()
        {
            LoadAssemblies(LoadJason());
        }

        public List<IListener> listeners { get; set; } = new List<IListener>(); 

        public List<string> LoadJason()
        {
            LoadJsonFile loadJsonFile = new LoadJsonFile();

            return loadJsonFile.GetAssembleyNames();
        }

        public void LoadAssemblies(List<string> assemblyPaths)
        {
            foreach (var assemblyToLoad in assemblyPaths)
            {
                var assembly = Assembly.LoadFrom(assemblyToLoad);

                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.GetInterface("IListener") is not null)
                    {
                        IListener listener = (IListener)Activator.CreateInstance(type)!;
                        listeners.Add(listener);
                        //tiesiog testas patikrint log metoda
                        listener.Log("yyyyyyy");
                    }
                }
            }
        }

        public void Track<T>(T obj)
        {
            var type = typeof(T);
            List<string> collectedInfo = new List<string>();

            if (type.IsDefined(typeof(TrackingEntityAttribute)))
            {
                //we collect all fields, methods and so on which has attributes applied
                var typeMembers = type.GetMembers().Where(x => x.IsDefined(typeof(TrackingPropertyAttribute)));

                

                foreach (var member in typeMembers)
                {
                    collectedInfo.Add($"{(member.Name ?? member.GetCustomAttribute<TrackingPropertyAttribute>()?.MemberName)}" +
                        $" = {(member.MemberType == MemberTypes.Property ? ((PropertyInfo)member).GetValue(obj) : ((FieldInfo)member).GetValue(obj))}");
                    //Console.WriteLine(member.Name);
                    //need to cast to PropertyInfo or FieldInfo to be able to access the value?
                    //Console.WriteLine(member.MemberType == MemberTypes.Property ? ((PropertyInfo)member).GetValue(obj) : ((FieldInfo)member).GetValue(obj));
                }
            }
        }
    }
}
