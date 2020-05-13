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

            currentTokenIndex++;
            while (tokens[currentTokenIndex].Type != TokenType.EndOfFile)
            {
                match(TokenType.SemiColon);

                currentTokenIndex++;
                TreeNode sibling = getStatement();

                currentNode.Siblings.Add(sibling);
                currentNode = sibling;

                currentTokenIndex++;
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
                case TokenType.Assign:
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
            TreeNode treeNode = new TreeNode(tokens[currentTokenIndex]);

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
            TreeNode treeNode = new TreeNode(tokens[currentTokenIndex]);

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
            TreeNode treeNode = new TreeNode(tokens[currentTokenIndex]);

            match(TokenType.Id);
            treeNode.ExtraText += tokens[currentTokenIndex].Lexeme;

            currentTokenIndex++;
            match(TokenType.Assign);

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            return treeNode;
        }

        private TreeNode getReadTreeNode()
        {
            TreeNode treeNode = new TreeNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            match(TokenType.Id);
            treeNode.ExtraText += tokens[currentTokenIndex].Lexeme;

            return treeNode;
        }
        private TreeNode getWriteTreeNode()
        {
            TreeNode treeNode = new TreeNode(tokens[currentTokenIndex]);

            currentTokenIndex++;
            treeNode.Children.Add(getExp());

            return treeNode;
        }

        private TreeNode getExp()
        {
            throw new NotImplementedException();
        }
        private TreeNode getSimpleExp()
        {
            throw new NotImplementedException();
        }
        private TreeNode getTerm()
        {
            throw new NotImplementedException();
        }
        private TreeNode getFactor()
        {
            throw new NotImplementedException();
        }

    }
}