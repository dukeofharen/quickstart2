using System.Windows.Forms;

public static class PanelExtensions
{
    //http://stackoverflow.com/questions/17752970/how-to-programmatically-scroll-a-panel
    public static void ScrollToBottom(this Panel p)
    {
        using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
        {
            p.ScrollControlIntoView(c);
            c.Parent = null;
        }
    }
}
