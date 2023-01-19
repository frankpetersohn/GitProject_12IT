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
        public static async void CreateXmlFile(string json, string savePath)
        {
            await Task.Run(() =>
            {
                try
                {
                    XmlSerializer serializer = new(json.GetType());
                    using (FileStream stream = new(savePath, FileMode.Create))
                    {
                        serializer.Serialize(stream, json);
                    }
                    Console.WriteLine($"XML-Datei erstellt: {savePath}");                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("XML-Datei konnte nicht erstellt werden. Fehler:\n" + ex.Message);
                }
            });



        }

    }
}
