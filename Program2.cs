public class Program2
{
    static void Main()
    {
        ActionMainMenu mainMenu = new ActionMainMenu("Interfaces Main Menu");
        
        ActionMenuItem dateItem = new ActionMenuItem("Show Date/Time");
        ActionMenuItem dateShowItem = new ActionMenuItem("Show Date");
        dateShowItem.ItemSelected += ShowDate;
        ActionMenuItem timeShowItem = new ActionMenuItem("Show Time");
        timeShowItem.ItemSelected += ShowTime;
        
        ActionMenuItem versionAndCapitalItem = new ActionMenuItem("Version and Capitals");
        ActionMenuItem versionShowItem = new ActionMenuItem("Show Version");
        versionShowItem.ItemSelected += ShowVersion;
        ActionMenuItem countCapitalsItem = new ActionMenuItem("Count Capitals");
        countCapitalsItem.ItemSelected += CountCapitals;

        dateItem.AddMenuItem(dateShowItem);
        dateItem.AddMenuItem(timeShowItem);
        versionAndCapitalItem.AddMenuItem(versionShowItem);
        versionAndCapitalItem.AddMenuItem(countCapitalsItem);

        mainMenu.AddMenuItem(dateItem);
        mainMenu.AddMenuItem(versionAndCapitalItem);
        
        mainMenu.Show();
    }

    public static void ShowDate()
    {
        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
    }

    public static void ShowTime()
    {
        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
    }

    public static void ShowVersion()
    {
        Console.WriteLine("App Version 23.2.4.9805");
    }

    public static void CountCapitals()
    {
        Console.Write("Please enter your sentence: ");
        string sentence = Console.ReadLine();
        int numberOfCapitalLetters = sentence.Count(char.IsUpper);
        Console.WriteLine($"There are {numberOfCapitalLetters} in your sentence.");
    }
}

