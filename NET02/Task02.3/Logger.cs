using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
                        listener.Log("yyyyyyy");
                        listener.Log("hhhhh");
                        //Console.WriteLine(listener.settings.FileName);
                    }
                }
            }
        }

        public void Track(object obj)
        {

        }
    }
}
