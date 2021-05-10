using System.Windows.Forms;
using TaskEngine.Models.Values;

namespace WinGenerator.CustomControls
{
    public class IdentifiedCheckBox: CheckBox, IIdentified
    {
        public IdentifiedCheckBox(string id)
        {
            Id = id;
            Text = id;
        }

        public string Id { get; }
    }
}