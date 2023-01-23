using PetersohnKlassenarbeit.Services;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        // Willkommensnachricht anzeigen
        Console.WriteLine(UserService.WelcomeMessage);

#if DEBUG
        int option = 2;
        string savePath = @"C:\Users\CAMAJUDE\OneDrive - B. Braun\Dokumente\Berufsschule\PETERSOHN\JsonKonverter\Data";
#else
        // Nutzer nach Option fragen
        int option = UserService.GetOption();

        // Nutzer nach Speicherpfad fragen
        string savePath = UserService.GetSavePath();       

#endif
        //URL nach Nutzereingabe erzeugen
        string url = UserService.GetApiOption(option);

        //Anfrage an API senden
        string json = ApiService.GetApiResponse(url);

        //CSV erzeugen
        CsvService csvService = new(json, Utils.GetSavePath(savePath, "csv"));
        csvService.CreateCsvFile();

        //XML erzeugen
        XmlService.CreateXmlFile(json, Utils.GetSavePath(savePath, "xml"));

        //Endscreen
        Console.WriteLine(UserService.ExitMessage);
        Console.ReadKey();
    }
}


