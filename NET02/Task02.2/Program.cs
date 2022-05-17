using Task02._2;

User Sam = new User("Sam");
Sam.AddWindowSettings(new WindowSettings("main", 50, 60, 70, 80));
Sam.AddWindowSettings(new WindowSettings("sample", 200, null, 30, 60));

User Bob = new User("Bob");
Bob.AddWindowSettings(new WindowSettings("nnnnnn", 50, 60, 70, 80));
Bob.AddWindowSettings(new WindowSettings("sample2", 200, null, 30, 60));

XMLHandler xmlHandler = new XMLHandler();
xmlHandler.SaveUsers(new List<User> { Sam, Bob});

Console.WriteLine(xmlHandler.GetXmlInfoForDisplay("Config\\writerSample.xml"));

JsonHandler jasonHandler = new JsonHandler();

jasonHandler.SaveUsers(xmlHandler.GetUsers("Config\\writerSample.xml"));
xmlHandler.SaveUsers(jasonHandler.GetUsers("Config"));
