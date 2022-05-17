using System.Text;
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

        private List<IListener> Listeners { get; set; } = new List<IListener>(); 

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
                        Listeners.Add(listener);
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
                    collectedInfo.Append($"{(member.GetCustomAttribute<TrackingPropertyAttribute>()?.MemberName ?? member.Name)}" +
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
            foreach (var listener in Listeners)
            {
                listener.Write(collectedInfo, logLevel);
            }
        }
    }
}
