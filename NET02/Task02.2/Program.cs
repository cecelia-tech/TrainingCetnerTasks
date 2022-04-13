using System.Text;
using System.Xml;
using System.Xml.Serialization;


using (XmlReader reader = XmlReader.Create("UserSettings.xml"))
{
    reader.MoveToContent();
    StringBuilder result = new StringBuilder();
    //string result;
    while (reader.Read())
    {
        //result = reader.ReadContentAsString();
        result.Append( reader.NodeType switch
        {
            XmlNodeType.Element when reader.Name == "login" => $"Login: {reader.GetAttribute("name")}\n",
            XmlNodeType.Element when reader.Name == "window" => $"{reader.GetAttribute("title")}( ",
            XmlNodeType.Text => $"{reader.Value}, ",
            XmlNodeType.EndElement when reader.Name == "window" => $")\n",
            XmlNodeType.EndElement when reader.Name == "login" => "-------------------\n",
            _ => ""
        });

        Console.Write(result.ToString());

    }
    Console.Write(result.ToString());
}
