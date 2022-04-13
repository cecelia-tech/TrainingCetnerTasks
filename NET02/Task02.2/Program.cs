using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


var filename = "UserSettings.xml";
var currentDirectory = "C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\Task02.2\\Config";
var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

XElement userInfo = XElement.Load(purchaseOrderFilepath);

IEnumerable<XElement> users = userInfo.Elements();
//IEnumerable<string> partNos = purchaseOrder.Descendants("login").Select(x => (string)x.Attribute("name"));

//users.Select(x => x.Elements());

foreach (var user in users)
{
    StringBuilder userInfoToDisplay = new StringBuilder();

    userInfoToDisplay.Append($"Login: {user.Attribute("name").Value} \n");

    //reikia user.Elements("window").Attributes("title") kad rasytu window pavadinima
    foreach (var userDetails in user.Elements("window"))
    {
        //IEnumerable
        var x = userDetails.Descendants();
        //galimai i for loopa arba kazka su contains
        foreach (var item in x)
        {
            //cia kol kas sudeda visus skaicius i viena eilute
            userInfoToDisplay.Append(item.Value).Append(", ");

        }
        //userInfoToDisplay.Append($"{userDetails.Value}");
        //Console.WriteLine(userDetails.Value);
    }
    //Console.WriteLine(user.Attribute("name").Value);
    Console.WriteLine(userInfoToDisplay.ToString());
}



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
