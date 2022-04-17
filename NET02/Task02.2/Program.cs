using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Task02._2;


//var filename = "UserSettings.xml";

//ReadsXML readsXML = new ReadsXML(filename);

//var users = readsXML.GetUsers();

//foreach (var item in users)
//{
//    Console.WriteLine(readsXML.GetUsersInfoToPrint(item));
//    XMLtoJSON XMLtoJSON = new XMLtoJSON(readsXML.GetUsersInfoToPrint(item));
//    XMLtoJSON.ConvertXMLtoJSON();
//}
//su situ interface mes galim keist kokius objektus mes norim saugot arba skaityt
//nes tik pakeitus new dali, visas kodas veiks taip pat


//IRepository repository = new XMLLoader()
//List<User> users = repository.ReadSettings();

//repository.Save();
User Sam = new User("Sam");
Sam.AddWindowSettings(new WindowSettings("main", 50, 60, 70, 80));
Sam.AddWindowSettings(new WindowSettings("sample", 200, null, 30, 60));

User Bob = new User("Bob");
Bob.AddWindowSettings(new WindowSettings("main2", 50, 60, 70, 80));
Bob.AddWindowSettings(new WindowSettings("sample2", 200, null, 30, 60));
//UsersWithSettings usersWithSettings = new UsersWithSettings();
//usersWithSettings.AddUsers(Sam);
//usersWithSettings.AddUsers(Bob);
XMLLoader loader = new XMLLoader();
loader.Write(new List<User> { Sam, Bob});

List<User> users = (loader.GetUsersFromXML("Config\\writerSample.xml"));

foreach (var user in users)
{
    Console.WriteLine(user.Name);
    foreach (var window in user.windowSettings)
    {
        Console.WriteLine(window.Title);
        Console.WriteLine(window.Height);
    }
}





loader.Read();











//foreach (var item in users)
//{
//    //var numberOfMainInUser = CountUserMain(item);
//    //var numberOfElementsInsideMain = CountElementsInMainWindow(item);
//    //var allElementsSet = AreAllElementsSet(item);

//    Console.WriteLine(PrintString(item)); 
//}



//bool IsCorrect()
//{
//    foreach (var item in users.Select(x => x.Elements("window")))
//    {
//        return item.Attributes("title").Where(x => x.Value == "main").Count() == 1;
//    }
//}

//Console.WriteLine(IsCorrect());
//IEnumerable<string> partNos = purchaseOrder.Descendants("login").Select(x => (string)x.Attribute("name"));

//users.Select(user => (user.Attribute("name").Value, ));
/*users.ToList().ForEach(x => userInfoToDisplay2.
Append($"Login: {x.Attribute("name").Value} \n").
Append($" {x.Elements("window").ToList().ForEach(xm => xm.Attribute("title").Value)}").*/
//Append(""));

/*foreach (var user in users)
{
    StringBuilder userInfoToDisplay = new StringBuilder();

    userInfoToDisplay.Append($"Login: {user.Attribute("name").Value} \n");

    //reikia user.Elements("window").Attributes("title") kad rasytu window pavadinima
    foreach (var userDetails in user.Elements("window"))
    {
        userInfoToDisplay.Append($" {userDetails.Attribute("title").Value}(");
        //IEnumerable
        var x = userDetails.Descendants();
       
        foreach (var item in x)
        {
            //cia kol kas sudeda visus skaicius i viena eilute
            userInfoToDisplay.Append(item.Value).Append(", ");

        }
        //userInfoToDisplay.Append($"{userDetails.Value}");
        userInfoToDisplay.Append(")\n");
        //Console.WriteLine(userDetails.Value);
    }
    //Console.WriteLine(user.Attribute("name").Value);
    Console.WriteLine(userInfoToDisplay.ToString());
}*/
//Console.WriteLine(userInfoToDisplay2.ToString());


/*using (XmlReader reader = XmlReader.Create("UserSettings.xml"))
{
    //reader.MoveToContent();
    StringBuilder result = new StringBuilder();
    
    //string result;
    while (reader.Read())
    {
        //if (reader.NodeType == XmlNodeType.Element && XmlNodeType.Element == )
        //{

        //}
        //result = reader.ReadContentAsString();
        result.Append( reader.NodeType switch
        {
            XmlNodeType.Element when reader.Name == "login" => $"Login: {reader.GetAttribute("name")}\n",
            XmlNodeType.Element when reader.Name == "window" => $"{reader.GetAttribute("title")}( ",
            XmlNodeType.Element when reader.Name == "top"  => $"{reader.Value}\n",
            XmlNodeType.Element when reader.Name == "left" => $"{reader.Value}, \n",
            XmlNodeType.Element when reader.Name == "width" => $"{reader.Value}, \n",
            XmlNodeType.Element when reader.Name == "height" => $"{reader.ReadElementContentAsStringAsync} \n",
            //XmlNodeType.Text => $"{reader.Value}, ",
            XmlNodeType.EndElement when reader.Name == "window" => $")\n",
            XmlNodeType.EndElement when reader.Name == "login" => "-------------------\n",
            _ => ""
        });

        //Console.Write(result.ToString());

    }
    Console.Write(result.ToString());
}*/
/*XElement document = XElement.Load("UserSettings.xml");
IEnumerable<XElement> elements = document.Value;
foreach (XElement element in elements)
{
    Console.WriteLine(element);
}*/

/*using ()
{

}*/
