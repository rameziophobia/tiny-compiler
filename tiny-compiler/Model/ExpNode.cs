using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCompiler.Model
{
    class ExpNode : TreeNode
    {
        public ExpNode(string name, TreeNode parent = null, List<TreeNode> children = null): base(name,parent,children)
        {
            this.Color = Microsoft.Msagl.Drawing.Color.Cyan;
            this.Shape = Microsoft.Msagl.Drawing.Shape.Box;
        }
    }
}
