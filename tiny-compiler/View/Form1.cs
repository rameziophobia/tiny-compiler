using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using TinyCompiler.Controller;
using TinyCompiler.Model;
using TreeNode = TinyCompiler.Model.TreeNode;

namespace TinyCompiler
{
    public partial class Form1 : Form
    {
        ParserTree parserTree = new ParserTree();
        Token temp = new Token();
        TreeNode readX;

        public Form1()
        {
            temp.Lexeme = "Read X";
            readX =  new ExpNode(temp);
            Token temp2 = new Token();
            temp2.Lexeme = "if"; 
            TreeNode if1 = new ExpNode(temp2);
            Token temp3 = new Token();
            temp3.Lexeme = "op (<)";  
            TreeNode op1 = new StatementNode(temp3);
            Token temp4 = new Token();
            temp4.Lexeme = "const (0)";  
            TreeNode const0 = new StatementNode(temp4);
            Token temp5 = new Token();
            temp5.Lexeme = "const (0)1";   
            TreeNode const02 = new StatementNode(temp5);
            Token temp6 = new Token();
            temp6.Lexeme = "id (x)";   
            TreeNode idX = new StatementNode(temp6);
            Token temp7 = new Token();
            temp7.Lexeme = "id (x)";   
            TreeNode idX2 = new StatementNode(temp7);
            Token temp8 = new Token();
            temp8.Lexeme = "id (x)";   
            TreeNode idX3 = new StatementNode(temp8);
            Token temp9 = new Token();
            temp9.Lexeme = "id (x)";   
            TreeNode idX4 = new StatementNode(temp9);
            Token temp10 = new Token();
            temp10.Lexeme = "id (fact)";   
            TreeNode idFact = new StatementNode(temp10);
            Token temp11 = new Token();
            temp11.Lexeme = "id (fact)";   
            TreeNode idFact2 = new StatementNode(temp11);
            Token temp12 = new Token();
            temp12.Lexeme = "asssign (fact)";   
            TreeNode assignFact = new ExpNode(temp12);
            Token temp13 = new Token();
            temp13.Lexeme = "asssign (fact)";   
            TreeNode assignFact2 = new ExpNode(temp13);
            Token temp14 = new Token();
            temp14.Lexeme = "op (-)";   
            TreeNode opMinus = new StatementNode(temp14);
            Token temp15 = new Token();
            temp15.Lexeme = "op (-)";   
            TreeNode opMinus2 = new StatementNode(temp15);
            Token temp16 = new Token();
            temp16.Lexeme = "op (-)";   
            TreeNode opMinus3 = new StatementNode(temp16);
            Token temp17 = new Token();
            temp17.Lexeme = "asssign (X)";   
            TreeNode assignX = new ExpNode(temp17);
            Token temp18 = new Token();
            temp18.Lexeme = "Const (1)";   
            TreeNode const1 = new StatementNode(temp18);
            Token temp19 = new Token();
            temp19.Lexeme = "Const (1)";   
            TreeNode const12 = new StatementNode(temp19);
            Token temp20 = new Token();
            temp20.Lexeme = "repeat";   
            TreeNode repeat = new ExpNode(temp20);
            Token temp21 = new Token();
            temp21.Lexeme = "write";   
            TreeNode write = new ExpNode(temp21);
            readX.Siblings.Add(if1);
            if1.Children.Add(op1);
            if1.Children.Add(assignFact);
            op1.Children.Add(const0);
            op1.Children.Add(idX);
            assignFact.Children.Add(const12);
            assignFact.Siblings.Add(repeat);
            repeat.Siblings.Add(write);
            write.Children.Add(idFact2);
            repeat.Children.Add(assignFact2);
            assignFact2.Children.Add(opMinus2);
            opMinus.Children.Add(const1);
            opMinus.Children.Add(idX3);
            assignFact2.Children.Add(assignX);
            assignX.Children.Add(opMinus);
            opMinus2.Children.Add(idFact);
            opMinus2.Children.Add(idX2);
            repeat.Children.Add(opMinus3);
            opMinus3.Children.Add(idX4);
            opMinus3.Children.Add(const02);
            InitializeComponent();
        }
        private void OpenFile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = OFD_Setup();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.OpenFile() != null)
                {
                    string fileText = File.ReadAllText(openFileDialog.FileName);
                    CodeText.Text = fileText;
                }
            }
        }
        private void Edit_button_Click(object sender, EventArgs e)
        {
            CodeText.ReadOnly = false;
            CodePanel.Visible = true;
            CodeText.Focus();
        }
        private void Save_button_Click(object sender, EventArgs e)
        {
            CodeText.ReadOnly = true;
            SaveFileDialog saveFileDialog = SFD_Setup();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    streamWriter.WriteLine(CodeText.Text);
                }
            }
        }
        private void LA_button_Click(object sender, EventArgs e)
        {
            if (CodeText.Text != "")
            {
                Scanner scanner = new Scanner(CodeText.Text + " ");
                var tokens = scanner.getTokens();
                string tableText = "";
                foreach (Token token in tokens)
                {
                    tableText += token.Lexeme + "\t\t\t\t" + token.Type.ToString() + "\n";
                }
                //tableForm.SetTableText(tableText);
                //tableForm.Show();
                CodePanel.Visible = false;
                TreeText.Text = tableText;

                string errorString = "";
                foreach (string error in Error.getErrorList())
                {
                    errorString += error + "\n";
                }
                if (errorString.Length != 0)
                {
                    ErrorText.Text = errorString;
                }
                else
                {
                    ErrorText.Text = "All Clear!";
                }
            }
        }
        private void TT_button_Click(object sender, EventArgs e)
        {
/*            Parser parser = new Parser(new Scanner(CodeText.Text + " ").getTokens());*/

            parserTree.makeGraph(readX);
            parserTree.showForm();
        }
        OpenFileDialog OFD_Setup()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|tiny file (*.tny)|*.tny|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            return openFileDialog;
        }
        SaveFileDialog SFD_Setup()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files(*.txt)| *.txt | tiny file(*.tny) | *.tny | All files(*.*) | *.* ";
            saveFileDialog.FilterIndex = 2;
            return saveFileDialog;
        }
        private void Exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
