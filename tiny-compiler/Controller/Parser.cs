using System;
using System.Collections.Generic;
using TinyCompiler.Model;

namespace TinyCompiler.Controller
{
    // Task I
    // todo custom exception
    // todo match()
    // todo display errors on the GUI

    // Task II
    // todo change rules to EBNF and implement their methods
    // todo implement methods: program stmt_sequence, statement, if_stmt, read_stmt, write_stmt, assign_stmt

    // Task III
    // todo change rules to EBNF and implement their methods
    // *note law 3ayzin t2asemo el methods ma3 ba3d differently -> sure
    // todo repeat_stmt, exp, comparison_op, simple_exp, add_op, term, mul_op, factor

    // Task IV
    // todo display the tree on the screen and architect the tree data structure
    // todo implement methods to add to that Tree structure

    // Task V
    // todo implement the general Parser class structure and helping w/ task 4
    // todo architect the system we ay 7aga fadla 3mtn
    // ana wa5ed el task da xD



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
            return getStmtSequence();
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
                case TokenType.Comment:
                    throw new NotImplementedException();
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
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);

            match(TokenType.Id);
            treeNode.ExtraText += "Assign";

            currentTokenIndex++;
            match(TokenType.Assign);

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            return treeNode;
        }

        private TreeNode getReadTreeNode()
        {
            TreeNode treeNode = new StatementNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            match(TokenType.Id);
            treeNode.ExtraText += tokens[currentTokenIndex].Lexeme;

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