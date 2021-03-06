using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ListenerInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WordListener
{
    public class ListenWords : IListener
    {
       public Config? settings { get; set; }

        public ListenWords()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("WordListenerConfig.json"));

            settings = allJsonSettings?["WordListener"]?.ToObject<Config>();
        }

        public void Write(string message, int logLevel)
        {
            if(logLevel >= settings?.LogLevel)
            {
                //creating document by giving file path ?? name?
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(settings?.FileName, WordprocessingDocumentType.Document))
                {
                    //Adding main document part
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    //Creating the document structure and adding text
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph paragraph = body.AppendChild(new Paragraph());
                    Run run = paragraph.AppendChild(new Run());
                    run.AppendChild(new Text(message));
                }
            }
        }
    }
}
