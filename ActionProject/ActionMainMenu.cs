public class ActionMainMenu
{
    private readonly ActionMenuItem r_MainMenuItem;
    private const string c_Divider = "==========";
    private readonly string r_MenuName;

    public ActionMainMenu(string i_MenuName)
    {
        r_MainMenuItem = new ActionMenuItem(i_MenuName);
        r_MainMenuItem.BeforeMenu = null;
    }

    public void Show()
    {
        ActionMenuItem menuItemSelection = r_MainMenuItem;
        while (true)
        {
            displayMenu(menuItemSelection);
            int userSelection = getUserSelection(menuItemSelection.SubItems.Count, menuItemSelection.BeforeMenu == null);
            
            if (userSelection == 0)
            {
                if (menuItemSelection.BeforeMenu == null)
                {
                    return;
                }
                else
                {
                    menuItemSelection = menuItemSelection.BeforeMenu;
                    Console.Clear();
                    continue;
                }
            }

            menuItemSelection = menuItemSelection.SubItems[userSelection - 1];
            if (menuItemSelection.SubItems.Count == 0)
            {
                menuItemSelection.Select();
                Console.WriteLine();
                menuItemSelection = menuItemSelection.BeforeMenu;
            }
            else
            {
                Console.Clear();
            }
        }
    }

    public void AddMenuItem(ActionMenuItem i_Item)
    {
        r_MainMenuItem.AddMenuItem(i_Item);
    }

    private void displayMenu(ActionMenuItem i_MenuItem)
    {
        writeHeader(i_MenuItem.Name);
        for (int i = 0; i < i_MenuItem.SubItems.Count; i++)
        {
            string subMenuItemName = i_MenuItem.SubItems[i].Name;
            Console.WriteLine($"{i + 1}: {subMenuItemName}");
        }

        string lastMenuOption = i_MenuItem.BeforeMenu == null ? "Exit" : "Back";
        Console.WriteLine($"0: {lastMenuOption}");
    }

    private void writeHeader(string i_Header)
    {
        Console.WriteLine(i_Header);
        Console.WriteLine(c_Divider);
        Console.WriteLine();
    }

    private int getUserSelection(int i_AmountOfItems, bool i_Exit)
    {
        int userSelection;
        string lastMenuOption = i_Exit ? "exit" : "back"; 
        while (true)
        {
            Console.Write($"Please enter your choice: (1 - {i_AmountOfItems}) or 0 to {lastMenuOption}: ");
            if (int.TryParse(Console.ReadLine(), out userSelection))
            {
                if (userSelection > i_AmountOfItems || userSelection < 0)
                {
                    Console.WriteLine("Please enter a number in the correct range.");
                    continue;
                }

                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }

        return userSelection;
    }
}