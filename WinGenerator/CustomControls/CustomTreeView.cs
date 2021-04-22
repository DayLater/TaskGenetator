using System.Linq;
using System.Windows.Forms;

namespace WinGenerator.CustomControls
{
    public class CustomTreeView: TreeView
    {
        public CustomTreeView()
        {
            AfterCheck += OnCheckedNode;
        }

        private void OnCheckedNode(object sender, TreeViewEventArgs args)
        {
            var node = args.Node;
            var checkedValue = node.Checked;
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked != checkedValue)
                    childNode.Checked = checkedValue;
            }

            var parent = node.Parent;
            if (parent != null && parent.Nodes.Cast<TreeNode>().All(child => child.Checked == checkedValue))
                parent.Checked = checkedValue;
        }

        public CustomTreeNode AddNode(string text)
        {
            var node = new CustomTreeNode(text);
            Nodes.Add(node);
            return node;
        }
    }
}