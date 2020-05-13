using System.Collections.Generic;

namespace TinyCompiler.Model
{
    class StatementNode : TreeNode
    {
        public StatementNode(Token token, TreeNode parent = null, List<TreeNode> children = null) : base(token, parent, children)
        {
            this.Color = Microsoft.Msagl.Drawing.Color.LimeGreen;
            this.Shape = Microsoft.Msagl.Drawing.Shape.Circle;

        }
    }
}
