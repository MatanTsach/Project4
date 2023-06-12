public class Program
{
    static void Main2()
    {
        MainMenu mainMenu = new MainMenu("Interfaces Main Menu");
        
        MenuItem dateItem = new MenuItem("Show Date/Time");
        MenuItem dateShowItem = new MenuItem("Show Date", new ShowDate());
        MenuItem timeShowItem = new MenuItem("Show Time", new ShowTime());

        MenuItem versionAndCapitalItem = new MenuItem("Version and Capitals");
        MenuItem versionShowItem = new MenuItem("Show Version", new ShowVersion());
        MenuItem countCapitalsItem = new MenuItem("Count Capitals", new CountCapitals());
        dateItem.AddMenuItem(dateShowItem);
        dateItem.AddMenuItem(timeShowItem);
        versionAndCapitalItem.AddMenuItem(versionShowItem);
        versionAndCapitalItem.AddMenuItem(countCapitalsItem);
        mainMenu.AddMenuItem(dateItem);
        mainMenu.AddMenuItem(versionAndCapitalItem);
        
        mainMenu.Show();
    }
}

public class ShowDate : IExecuteable
{
    public void Execute()
    {
        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
    }
}

public class ShowTime : IExecuteable
{
    public void Execute()
    {
        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
    }
}

public class ShowVersion : IExecuteable
{
    public void Execute()
    {
        Console.WriteLine("App Version 23.2.4.9805");
    }
}

public class CountCapitals : IExecuteable
{
    public void Execute()
    {
        Console.Write("Please enter your sentence: ");
        string sentence = Console.ReadLine();
        int numberOfCapitalLetters = sentence.Count(char.IsUpper);
        Console.WriteLine($"There are {numberOfCapitalLetters} in your sentence.");
    }
}

