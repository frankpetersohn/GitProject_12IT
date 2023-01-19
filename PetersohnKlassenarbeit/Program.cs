using PetersohnKlassenarbeit.Services;
using System.Net;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var consoleService = new UserService();

        // Willkommensnachricht anzeigen
        Console.WriteLine(consoleService.WelcomeMessage);
        
#if DEBUG
        int option = 2;
        string savePath = @"C:\Users\CAMAJUDE\Downloads";
#else
        // Nutzer nach Option fragen
        int option = UserService.GetOption();

        // Nutzer nach Speicherpfad fragen
        string savePath = UserService.GetSavePath();       

#endif

        string url = UserService.GetApiOption(option);

        //Anfrage an API senden
        var json = await ApiService.GetServerResponseAsJson(url);

        CsvService.CreateCsvFile(json, Utils.GetSavePath(savePath, "csv"));
        XmlService.CreateXmlFile(json, Utils.GetSavePath(savePath, "xml"));


        Console.WriteLine("Konvertierung erfolgreich!\nDrücken Sie eine beliebige Taste um das Programm zu beenden...");
    }
}


