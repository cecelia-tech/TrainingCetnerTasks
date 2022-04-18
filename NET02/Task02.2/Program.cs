using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Task02._2;

User Sam = new User("Sam");
Sam.AddWindowSettings(new WindowSettings("main", 50, 60, 70, 80));
Sam.AddWindowSettings(new WindowSettings("sample", 200, null, 30, 60));

User Bob = new User("Bob");
Bob.AddWindowSettings(new WindowSettings("nnnnnn", 50, 60, 70, 80));
Bob.AddWindowSettings(new WindowSettings("sample2", 200, null, 30, 60));

XMLLoader loader = new XMLLoader();
loader.SaveUsersToXml(new List<User> { Sam, Bob});

List<User> users = (loader.GetUsers("Config\\writerSample.xml"));

foreach (var user in users)
{
    Console.WriteLine(user.Name);
    foreach (var window in user.WindowSettings)
    {
        Console.WriteLine(window.Title);
        Console.WriteLine(window.Height);
    }
}

Console.WriteLine(loader.GetXmlInfoForDisplay("Config\\writerSample.xml"));


JSONSaver jasonSaver = new JSONSaver();

jasonSaver.SaveUsers("Config\\writerSample.xml");
