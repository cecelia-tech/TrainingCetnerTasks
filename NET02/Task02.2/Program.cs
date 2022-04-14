using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


var filename = "UserSettings.xml";
var currentDirectory = "C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\Task02.2\\Config";
var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

XElement userInfo = XElement.Load(purchaseOrderFilepath);

//kadangi elements, atiduoda pirmus <config> vaikus, kurie yra <login> ir todel mano users yra 2
//pasirasom "login", nes jeigu pakliutu kitokiu negu <login>, kad visko nesugadintu
IEnumerable<XElement> users = userInfo.Elements("login");
StringBuilder userInfoToDisplay2 = new StringBuilder();

//mano users yra 2 login elementai su viskuo viduje medzio atzvilgiu, ne plokscia

int CountUserMain(XElement user)
{
        return user.Elements("window").Where(window => window.Attribute("title").Value == "main").Count();
}

//cia patikrinam ar window turi 4 elementus arba nei vieno
int CountElementsInMainWindow(XElement user)
{
    //cia gaunam bendra vaiku skaiciu is 1 window main 
    return user.Elements("window").Where(window => window.Attribute("title").Value == "main").Descendants().Count();
}


void PrintString(XElement user)
{
    StringBuilder infoToPrint = new StringBuilder();
    infoToPrint.Append($"Login: {user.Attribute("name").Value} \n");

    if (CountUserMain(user) == 1)
    {
        foreach (var window in user.Elements("window"))
        {
            infoToPrint.Append($"\t{window.Attribute("title").Value}");

            var elements = window.Descendants();
            infoToPrint.Append($"({(elements.Any(x => x.Name == "top") != false ? elements.First(x => x.Name == "top").Value : '?') }," +
                $"{(elements.Any(x => x.Name == "left") != false ? elements.First(x => x.Name == "left").Value : '?') }," +
                $"{(elements.Any(x => x.Name == "width") != false ? elements.First(x => x.Name == "width").Value : '?') }," +
                $"{(elements.Any(x => x.Name == "height") != false ? elements.First(x => x.Name == "height").Value : '?') }," +
                $")\n");
            
            /*foreach (var windowNode in window.Descendants())
            {
                //infoToPrint.Append(windowNode.Name switch
                //{
                //    windowNode
                //}
                    
                //);
                if (windowNode.Value != "")
                {
                    infoToPrint.Append(windowNode.Value);
                }
                else
                {
                    infoToPrint.Append("?");
                }
            }
            infoToPrint.Append(")\n");*/
        }
    }
    Console.WriteLine(infoToPrint.ToString());
}


/*bool AreAllElementsSet(XElement user)
{
    var nodesInsideWindow = user.Elements("window").Where(window => window.Attribute("title").Value == "main").Descendants();

    List<string> titlesOfElements = new List<string>() { "top", "left", "width", "height"};

    var namesOfElements = nodesInsideWindow.Select(element => element.Name);

    foreach (var node in nodesInsideWindow)
    {
        foreach (var item in titlesOfElements)
        {
            if (true)
            {

            }
        }
        if (!titlesOfElements.Contains(node.Name.ToString()) && node.Value == String.Empty)
        {
            return false;
        }
    }

    return true;
}*/




foreach (var item in users)
{
    //var numberOfMainInUser = CountUserMain(item);
    //var numberOfElementsInsideMain = CountElementsInMainWindow(item);
    //var allElementsSet = AreAllElementsSet(item);

    PrintString(item);
}






//users.Select(user => user.Attributes("title")).Count();


//foreach (var user in users.Select(user => user.Attributes("main")))
//{
//    Console.WriteLine(user);
//}
//users.Select(user => user.Attributes("main").ToList().ForEach(windowSuMain => Console.WriteLine(windowSuMain)));
//void IsCorrect()
//{
//return users.Select(x => x.Elements("window").Attributes("title")).Where(x => x).Count();
//return users.Where(x => x.Elements("window").Attributes("title").Value == "main").Select(m => m.Elements("window")).Count();
//visiWindowSuTitle.Where(x => x.V
//return users.Select(x => x.Attributes("title").
//Where(x => x.Value == "main" && x.Value == "help")).Count();
//return users.Descendants("login").Where(x => x.Elements("window").Contains(x.Element("main"))).Select(xm => xm.Element("window")).Count();
//users.Where(x => x.Name == "window").Select(x => x.Attributes("main"));


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
