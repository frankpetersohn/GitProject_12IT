using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PetersohnKlassenarbeit.Services
{
    internal class XmlService
    {
        public static void CreateXmlFile(string json, string savePath)
        {
            try
            {
                using (FileStream stream = new(savePath, FileMode.Create))
                {
                    // JSON als string übergeben und mit XMLserializer in .xml-Datei schreiben
                    new XmlSerializer(json.GetType()).Serialize(stream, json);
                }
                Console.WriteLine($"\nXML-Datei erstellt: {savePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
