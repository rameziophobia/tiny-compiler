﻿using Microsoft.Msagl.Drawing;
namespace TinyCompiler.Model
{
    class StatementNode : TreeNode
    {
        public StatementNode(Token token, TreeNode parent = null) : base(token, parent)
        {
            Color = Color.LimeGreen;
            Shape = Shape.Circle;
        }
    }
}
