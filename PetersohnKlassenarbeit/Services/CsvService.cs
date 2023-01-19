using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PetersohnKlassenarbeit.Services
{
    internal class CsvService
    {
        public static async void CreateCsvFile(string json, string savePath)
        {
            await Task.Run(() =>
            {
                try
                {
                    //var jsonObject = JsonConvert.DeserializeObject<string>(json);
                    using (var writer = new StreamWriter(savePath))
                    using (var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(json);
                    }
                    Console.WriteLine($"CSV-Datei erstellt: {savePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CSV-Datei konnte nicht erstellt werden. Fehler:\n" + ex.Message);
                }
            });


        }
    }
}
