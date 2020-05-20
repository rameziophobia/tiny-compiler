using Microsoft.Msagl.Drawing;

namespace TinyCompiler.Model
{
    class ExpNode : TreeNode
    {
        public ExpNode(Token token, TreeNode parent = null) : base(token, parent)
        {
            Color = Color.LimeGreen;
            Shape = Shape.Circle;
        }

        public override string getDisplayLabel()
        {
            return $"{Token.Type}\n({Token.Lexeme})\n{ExtraText}";
        }
    }
}
