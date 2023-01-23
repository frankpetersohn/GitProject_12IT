using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace PetersohnKlassenarbeit.Services
{
    internal class CsvService
    {
        public CsvService(string json, string savePath)
        {
            JObject jObject = JObject.Parse(json);
            JArray = jObject[jObject.First.Path.ToString()] as JArray;
            SavePath = savePath;
        }

        public string SavePath { get; set; }

        public JArray JArray { get; set; } = new();


        public List<string> GetHeadersFromJson()
        {
            try
            {
                List<string> headers = new();

                
                foreach (JObject obj in JArray.Children<JObject>())
                {
                    //Einmaliger Durchlauf der Keys für die Spaltenbezeichnung
                    foreach (var property in obj.Properties())
                    {
                        headers.Add(property.Name);
                    }
                    break;
                }
                return headers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<string>();
            }
        }

        public void CreateCsvFile()
        {
            try
            {
                using StreamWriter writer = new(SavePath);
                var headers = this.GetHeadersFromJson();

                //Spaltenüberschriften einfügen
                writer.WriteLine(String.Join(",", headers));

                //Zeilen einfügen
                foreach (var entry in JArray)
                {
                    writer.WriteLine(String.Join(",", entry.Values()));
                }

                Console.WriteLine($"\nCSV-Datei erstellt: {SavePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
