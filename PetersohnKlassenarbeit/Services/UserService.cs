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
        public static string WelcomeMessage = $"Mit dieser Anwendung können Sie die API '{ApiService.ApiUrl}' ansprechen.\nMöchten Sie sich die Berufe oder Lernfelder anzeigen lassen?";

        public static string ExitMessage = "\nKonvertierung abgeschlossen!\nDrücken Sie eine beliebige Taste um das Programm zu beenden...";
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
                Console.WriteLine("1. Berufe");
                Console.WriteLine("2. Lernfelder");

                //Falls der Nutzer etwas anderes als die erlaubten Optionen eingibt, wird eine erneute Eingabe gefordert
                if (int.TryParse(Console.ReadLine(), out int option) && (option == 1 || option == 2))
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("\nUngültige Eingabe.\nBitte wählen Sie entweder 1 oder 2.");
                }
            }
        }

        public static string GetSavePath()
        {
            while (true)
            {
                Console.WriteLine("\nBitte geben Sie einen gültigen Ordner an, indem die CSV und XML gespeichert werden sollen:");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    return path;
                }
                else
                {
                    Console.WriteLine("Ungültiger Pfad. Bitte versuchen Sie es erneut:\n");
                }
            }
        }
    }
}
