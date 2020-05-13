using Microsoft.Msagl.Drawing;

namespace TinyCompiler.Model
{
    class ExpNode : TreeNode
    {
        public ExpNode(Token token, TreeNode parent = null) : base(token, parent)
        {
            Color = Color.Cyan;
            Shape = Shape.Box;
        }
    }
}
