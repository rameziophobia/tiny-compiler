using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCompiler.Model
{
    class ExpNode : TreeNode
    {
        public ExpNode(Token token, TreeNode parent = null, List<TreeNode> children = null) : base(token, parent, children)
        {
            this.Color = Microsoft.Msagl.Drawing.Color.Cyan;
            this.Shape = Microsoft.Msagl.Drawing.Shape.Box;
        }
    }
}
