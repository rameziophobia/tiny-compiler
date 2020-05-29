using System.Collections.Generic;
using TinyCompiler.Model;
using TinyCompiler.Model.Errors;

namespace TinyCompiler.Controller
{

    class Parser
    {
        private readonly List<Token> tokens;
        private int currentTokenIndex = 0;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            Token endOfFile = new Token();
            endOfFile.Type = TokenType.EndOfFile;
            tokens.Add(endOfFile);
        }

        public TreeNode parse()
        {
            try
            {
                return getStmtSequence();
            }
            catch (InvalidSyntaxException)
            {
            }
            return null;
        }

        // change return type
        public void getGraphData()
        {

        }

        private TreeNode getStmtSequence()
        {
            TreeNode rootNode = getStatement();
            TreeNode currentNode = rootNode;


            while (tokens[currentTokenIndex + 1].Type != TokenType.EndOfFile &&
                tokens[currentTokenIndex + 1].Type != TokenType.End &&
                tokens[currentTokenIndex + 1].Type != TokenType.Else &&
                tokens[currentTokenIndex + 1].Type != TokenType.Until
                )
            {
                currentTokenIndex++;
                match(TokenType.SemiColon);

                currentTokenIndex++;
                TreeNode sibling = getStatement();

                currentNode.Siblings.Add(sibling);
                currentNode = sibling;
            }
            return rootNode;
        }
        private TreeNode getStatement()
        {
            switch (tokens[currentTokenIndex].Type)
            {
                case TokenType.If:
                    return getIfTreeNode();
                case TokenType.Repeat:
                    return getRepeatTreeNode();
                case TokenType.Read:
                    return getReadTreeNode();
                case TokenType.Write:
                    return getWriteTreeNode();
                case TokenType.Id:
                    return getAssignTreeNode();
                default:
                    throw new InvalidSyntaxException(tokens[currentTokenIndex]);
            }
        }
        private void match(TokenType expected) // todo rename
        {
            if (tokens[currentTokenIndex].Type != expected)
            {
                throw new InvalidSyntaxException(tokens[currentTokenIndex], expected);
            }
        }

        private TreeNode getIfTreeNode()
        {
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            currentTokenIndex++;
            match(TokenType.Then);

            currentTokenIndex++;
            treeNode.Children.Add(getStmtSequence());

            currentTokenIndex++;
            if (tokens[currentTokenIndex].Type == TokenType.Else)
            {
                match(TokenType.Else);
                currentTokenIndex++;
                treeNode.Children.Add(getStmtSequence());
                currentTokenIndex++;
            }
            match(TokenType.End);

            return treeNode;
        }

        private TreeNode getRepeatTreeNode()
        {
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            treeNode.Children.Add(getStmtSequence());

            currentTokenIndex++;
            match(TokenType.Until);

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            return treeNode;
        }
        private TreeNode getAssignTreeNode()
        {
            string extraText = $"({tokens[currentTokenIndex].Lexeme})";

            currentTokenIndex++;
            match(TokenType.Assign);
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);
            treeNode.ExtraText += extraText;

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            return treeNode;
        }

        private TreeNode getReadTreeNode()
        {
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            match(TokenType.Id);
            treeNode.ExtraText += $"({tokens[currentTokenIndex].Lexeme})";

            return treeNode;
        }
        private TreeNode getWriteTreeNode()
        {
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            return treeNode;
        }

        private TreeNode getExp()
        {
            TreeNode treeNode = getSimpleExp();
            TreeNode tempNode = treeNode;


            if (tokens[currentTokenIndex + 1].Type == TokenType.LessThan ||
                tokens[currentTokenIndex + 1].Type == TokenType.GreaterThan ||
                tokens[currentTokenIndex + 1].Type == TokenType.IsEqual ||
                tokens[currentTokenIndex + 1].Type == TokenType.IsNotEqual)
            {
                currentTokenIndex++;
                match(tokens[currentTokenIndex].Type);
                treeNode = new ExpNode(tokens[currentTokenIndex]);
                treeNode.Children.Add(tempNode);
                currentTokenIndex++;
                treeNode.Children.Add(getSimpleExp());
            }

            return treeNode;
        }

        private TreeNode getSimpleExp()
        {
            TreeNode treeNode = getTerm();
            TreeNode tempNode = treeNode;

            while (tokens[currentTokenIndex + 1].Type == TokenType.Plus ||
                tokens[currentTokenIndex + 1].Type == TokenType.Minus)
            {
                currentTokenIndex++;
                match(tokens[currentTokenIndex].Type);

                treeNode = new ExpNode(tokens[currentTokenIndex]);
                treeNode.Children.Add(tempNode);
                currentTokenIndex++;
                treeNode.Children.Add(getTerm());
                tempNode = treeNode; // gamed
            }

            return treeNode;
        }

        private TreeNode getTerm()
        {
            TreeNode treeNode = getFactor();
            TreeNode tempNode = treeNode;

            while (tokens[currentTokenIndex + 1].Type == TokenType.Mult ||
                tokens[currentTokenIndex + 1].Type == TokenType.Division)
            {
                currentTokenIndex++;
                match(tokens[currentTokenIndex].Type);

                treeNode = new ExpNode(tokens[currentTokenIndex]);
                treeNode.Children.Add(tempNode);
                currentTokenIndex++;
                treeNode.Children.Add(getFactor());
                tempNode = treeNode; // gamed
            }

            return treeNode;
        }
        private TreeNode getFactor()
        {
            TreeNode treeNode;
            switch (tokens[currentTokenIndex].Type)
            {
                case TokenType.BracketLeft:
                    match(TokenType.BracketLeft);
                    currentTokenIndex++;
                    treeNode = getExp();
                    currentTokenIndex++;
                    match(TokenType.BracketRight);
                    break;

                case TokenType.Id:
                    treeNode = new ExpNode(tokens[currentTokenIndex]);
                    match(TokenType.Id);
                    break;

                case TokenType.Integer:
                    treeNode = new ExpNode(tokens[currentTokenIndex]);
                    match(TokenType.Integer);
                    break;

                case TokenType.Float:
                    treeNode = new ExpNode(tokens[currentTokenIndex]);
                    match(TokenType.Float);
                    break;
                default:
                    throw new InvalidSyntaxException(tokens[currentTokenIndex]);
            }

            return treeNode;
        }
    }
}