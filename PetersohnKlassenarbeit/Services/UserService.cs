using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PetersohnKlassenarbeit.Services
{
    internal class UserService
    {

        public string WelcomeMessage = $"Mit dieser Anwendung können Sie die API '{ApiService.ApiUrl}' ansprechen.\nMöchten Sie sich die Berufe oder Lernfelder anzeigen lassen?";

        public static string GetApiOption(int option)
        {

            var url = ApiService.ApiUrl;
            if (option == 1)
            {
                url += "berufe.json";
            }
            else if (option == 2)
            {
                url += "lernfelder.json";
            }
            return url;
        }

        public static int GetOption()
        {
            while (true)
            {
                Console.WriteLine("Wählen Sie eine Option und geben Sie die zugehörige Nummer an:");
                Console.WriteLine("1. Berufe");
                Console.WriteLine("2. Lernfelder");
                if (int.TryParse(Console.ReadLine(), out int option) && (option == 1 || option == 2))
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe.\nBitte wählen Sie entweder 1 oder 2.");
                }
            }
        }

        public static string GetSavePath()
        {
            while (true)
            {
                Console.WriteLine("Bitte geben Sie einen gültigen Ordner an, indem die CSV und XML gespeichert werden sollen:");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    return path;
                }
                else
                {
                    Console.WriteLine("Ungültiger Pfad. Bitte versuchen Sie es erneut.");
                }
            }
        }
    }
}
