using System.Windows.Forms;

namespace WinGenerator.CustomControls
{
    public class CustomTreeNode: TreeNode
    {
        public CustomTreeNode(string text): base(text) { }
        
        public CustomTreeNode AddNode(string text)
        {
            var node = new CustomTreeNode(text);
            Nodes.Add(node);
            return node;
        }
    }
}