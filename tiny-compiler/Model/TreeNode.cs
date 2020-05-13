using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;
using System.Diagnostics;

namespace TinyCompiler.Model
{
    class TreeNode
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public TreeNode Parent {get;set;}
        public List<TreeNode> Children { get; set; }

        public List<TreeNode> Siblings { get; set; }
        public Microsoft.Msagl.Drawing.Shape Shape { get; set; }
        public Microsoft.Msagl.Drawing.Color Color { get; set; }
        private static int counter = 0; 
        public TreeNode(string name = "", TreeNode parent = null, List<TreeNode> children = null, List<TreeNode> siblings = null)
        {
            this.Name = name;
            this.ID = name + counter;
            counter++;
            this.Children = new List<TreeNode>();
            this.Siblings = new List<TreeNode>();
            if (parent != null)
            {
                this.Parent = parent;
            }
            if (children != null)
            {
                this.Children = children;
            } 
            if (siblings != null)
            {
                this.Siblings = siblings;
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
        public void AddSibling(TreeNode sibling)
        {
            this.Siblings.Add(sibling);
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
