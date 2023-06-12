public class MenuItem
{
    private readonly string r_MenuName;
    private readonly List<MenuItem> r_SubItems;
    private IExecuteable r_Action;
    private MenuItem m_BeforeMenu;

    public MenuItem(string i_MenuName)
    {
        r_MenuName = i_MenuName;
        r_SubItems = new List<MenuItem>();
    }

    public MenuItem(string i_MenuName, IExecuteable i_Executeable)
        : this(i_MenuName)
    {
        r_Action = i_Executeable;
    }

    public MenuItem BeforeMenu
    {
        get { return m_BeforeMenu; }
        set { m_BeforeMenu = value; }
    }

    public void AddMenuItem(MenuItem i_MenuItem)
    {
        i_MenuItem.BeforeMenu = this;
        r_SubItems.Add(i_MenuItem);
    }

    public List<MenuItem> SubItems
    {
        get { return r_SubItems; }
    }

    public IExecuteable Action
    {
        get { return r_Action; }
        set { r_Action = value; }
    }

    public string Name
    {
        get { return r_MenuName; }
    }
}