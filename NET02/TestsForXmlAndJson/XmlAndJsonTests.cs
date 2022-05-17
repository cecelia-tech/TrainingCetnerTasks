using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Task02._2;

namespace TestsForXmlAndJson
{
    [TestClass]
    public class XmlAndJsonTests
    {
        [TestMethod]
        public void TestSaveUsersToXML()
        {
            User Sam = new User("Sam");
            Sam.AddWindowSettings(new WindowSettings("main", 50, 60, 70, 80));
            Sam.AddWindowSettings(new WindowSettings("sample", 200, null, 30, 60));

            User Bob = new User("Bob");
            Bob.AddWindowSettings(new WindowSettings("nnnnnn", 50, 60, 70, 80));
            Bob.AddWindowSettings(new WindowSettings("sample2", 200, null, 30, 60));

            XMLHandler loader = new XMLHandler();
            loader.SaveUsers(new List<User> { Sam, Bob });

            Assert.IsTrue(File.Exists($"C:\\Users\\VitaGriciute\\source\\repos\\" +
                $"TrainingCetnerTasks\\NET02\\Task02.2\\bin\\Debug\\net6.0\\Config" +
                $"\\writerSample.xml"));
        }

        [TestMethod]
        public void TestGetUsers()
        {
            User Sam = new User("Sam");
            Sam.AddWindowSettings(new WindowSettings("main", 50, 60, 70, 80));
            Sam.AddWindowSettings(new WindowSettings("sample", 200, null, 30, 60));

            User Bob = new User("Bob");
            Bob.AddWindowSettings(new WindowSettings("nnnnnn", 50, 60, 70, 80));
            Bob.AddWindowSettings(new WindowSettings("sample2", 200, null, 30, 60));

            XMLHandler loader = new XMLHandler();
            loader.SaveUsers(new List<User> { Sam, Bob });

            List<User> users = (loader.GetUsers($"C:\\Users\\VitaGriciute\\source\\repos\\" +
                $"TrainingCetnerTasks\\NET02\\Task02.2\\bin\\Debug\\net6.0\\Config" +
                $"\\writerSample.xml"));

            Assert.IsNotNull(users);

            foreach (var user in users)
            {
                Assert.IsNotNull(user);
            }
        }

        [TestMethod]
        public void GetXmlInfoForDisplay()
        {
            User Sam = new User("Sam");
            Sam.AddWindowSettings(new WindowSettings("main", 50, 60, 70, 80));
            Sam.AddWindowSettings(new WindowSettings("sample", 200, null, 30, 60));

            User Bob = new User("Bob");
            Bob.AddWindowSettings(new WindowSettings("nnnnnn", 50, 60, 70, 80));
            Bob.AddWindowSettings(new WindowSettings("sample2", 200, null, 30, 60));

            XMLHandler loader = new XMLHandler();
            loader.SaveUsers(new List<User> { Sam, Bob });
            Assert.IsNotNull(loader.GetXmlInfoForDisplay("Config\\writerSample.xml"));
        }

        [TestMethod]
        public void TestJsonSaveUsers()
        {
            JsonHandler jasonSaver = new JsonHandler();

            //jasonSaver.SaveUsers($"C:\\Users\\VitaGriciute\\source\\repos\\" +
            //    $"TrainingCetnerTasks\\NET02\\Task02.2\\bin\\Debug\\net6.0\\Config" +
            //    $"\\writerSample.xml");

            Assert.IsTrue(Directory.Exists($"C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\Task02.2\\bin\\Debug\\net6.0\\Config\\Bob"));
        }
    }
}
