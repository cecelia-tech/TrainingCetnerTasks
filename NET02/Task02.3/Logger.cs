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
                    }
                }
            }
        }

        public void Track<T>(T obj)
        {
            var type = typeof(T);

            StringBuilder collectedInfo = new StringBuilder();

            if (type.IsDefined(typeof(TrackingEntityAttribute)))
            {
                //we collect all fields, methods and so on which has attributes applied
                var typeMembers = type.GetMembers().Where(x => x.IsDefined(typeof(TrackingPropertyAttribute)));

                foreach (var member in typeMembers)
                {
                    collectedInfo.Append($"{(member.Name ?? member.GetCustomAttribute<TrackingPropertyAttribute>()?.MemberName)}" +
                        $" = {(member.MemberType == MemberTypes.Property ? ((PropertyInfo)member).GetValue(obj) : ((FieldInfo)member).GetValue(obj))}\n");
                }
            }

            if (collectedInfo.ToString().Length != 0)
            {
                WriteInfoToFiles(collectedInfo.ToString(), 4);
            } 
        }

        public void WriteInfoToFiles(string collectedInfo, int logLevel)
        {
            foreach (var listener in listeners)
            {
                listener.Write(collectedInfo, logLevel);
            }
            Console.WriteLine(collectedInfo + logLevel);
        }
    }
}
