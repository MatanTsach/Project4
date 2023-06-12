public class ActionMenuItem
{
    private readonly string r_MenuName;
    private readonly List<ActionMenuItem> r_SubItems;
    private ActionMenuItem m_BeforeMenu;
    public event Action ItemSelected;

    public ActionMenuItem(string i_MenuName)
    {
        r_MenuName = i_MenuName;
        r_SubItems = new List<ActionMenuItem>();
    }

    public ActionMenuItem BeforeMenu
    {
        get { return m_BeforeMenu; }
        set { m_BeforeMenu = value; }
    }

    public void AddMenuItem(ActionMenuItem i_MenuItem)
    {
        i_MenuItem.BeforeMenu = this;
        r_SubItems.Add(i_MenuItem);
    }

    public List<ActionMenuItem> SubItems
    {
        get { return r_SubItems; }
    }

    public void Select()
    {
        OnSelected();
    }

    protected virtual void OnSelected()
    {
        if (ItemSelected != null)
        {
            ItemSelected.Invoke();
        }
    }

    public string Name
    {
        get { return r_MenuName; }
    }
}