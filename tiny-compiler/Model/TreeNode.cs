using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;

namespace TinyCompiler.Model
{
    class TreeNode
    {
        public string Name { get; set; }
        public TreeNode Parent {get;set;}
        public List<TreeNode> Children { get; set; }
        public Microsoft.Msagl.Drawing.Shape Shape { get; set; }
        public Microsoft.Msagl.Drawing.Color Color { get; set; }
        public TreeNode(string name = "", TreeNode parent = null, List<TreeNode> children = null)
        {
            this.Name = name;
            this.Children = new List<TreeNode>();
            if (parent != null)
            {
                this.Parent = parent;
            }
            if (children != null)
            {
                this.Children = children;
            }
            Shape =  Microsoft.Msagl.Drawing.Shape.Diamond;
            Color = Microsoft.Msagl.Drawing.Color.Red;
        }
        public void setParent(TreeNode parent)
        {
            this.Parent = parent;
        }
        public void AddChild(TreeNode child)
        {
            this.Children.Add(child);
        }
        public void AddChildren(List<TreeNode> children)
        {
            this.Children.AddRange(children);
        }

        public void removeChild(TreeNode childToRemove)
        {
            TreeNode removedNode = null;
            foreach (var child in Children)
            {
                if (child.Name == childToRemove.Name)
                {
                    removedNode = child;
                }
            }
            if (removedNode != null)
            {
                removedNode.Parent = null;
                Children.Remove(removedNode);
            }

        }
    }
}
