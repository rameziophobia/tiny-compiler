using Microsoft.Msagl.Drawing;
using System.Collections.Generic;

namespace TinyCompiler.Model
{
    class TreeNode
    {
        public string ID { get; set; }
        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; }
        public List<TreeNode> Siblings { get; set; }
        public Shape Shape { get; set; }
        public Color Color { get; set; }
        public Token Token { get; }
        public string ExtraText { get; set; }

        private static int counter = 0;

        public TreeNode(Token token, TreeNode parent = null)
        {
            ID = counter.ToString();
            counter++;
            Children = new List<TreeNode>();
            Siblings = new List<TreeNode>();
            Parent = parent;
            Shape = Shape.Diamond;
            Color = Color.Red;
            Token = token;
        }

        public virtual string getDisplayLabel()
        {
            return Token.Type + "\n" + ExtraText;
        }

        //public void removeChild(TreeNode childToRemove)
        //{
        //    TreeNode removedNode = null;
        //    foreach (var child in Children)
        //    {
        //        if (child.Name == childToRemove.Name)
        //        {
        //            removedNode = child;
        //        }
        //    }
        //    if (removedNode != null)
        //    {
        //        removedNode.Parent = null;
        //        Children.Remove(removedNode);
        //    }
        //}
    }
}
