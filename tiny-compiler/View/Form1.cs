using System;
using System.IO;
using System.Windows.Forms;
using TinyCompiler.Controller;
using TinyCompiler.Model;
using TinyCompiler.View;
using TreeNode = TinyCompiler.Model.TreeNode;

namespace TinyCompiler
{
    public partial class Form1 : Form
    {
        ParserTree parserTree = new ParserTree();
        TreeNode readX = new ExpNode("Read X");
        TreeNode if1 = new ExpNode("if");
        TreeNode op1 = new StatementNode("op (<)");
        TreeNode const0 = new StatementNode("const (0)");
        TreeNode const02 = new StatementNode("const (0)");
        TreeNode idX = new StatementNode("id (x)");
        TreeNode idX2 = new StatementNode("id (x)");
        TreeNode idX3 = new StatementNode("id (x)");
        TreeNode idX4 = new StatementNode("id (x)");
        TreeNode idFact = new StatementNode("id (fact)");
        TreeNode idFact2 = new StatementNode("id (fact)");
        TreeNode assignFact = new ExpNode("asssign (fact)");
        TreeNode assignFact2 = new ExpNode("asssign (fact)");
        TreeNode opMinus = new StatementNode("op (-)");
        TreeNode opMinus2 = new StatementNode("op (-)");
        TreeNode opMinus3 = new StatementNode("op (-)");
        TreeNode assignX = new ExpNode("asssign (X)");
        TreeNode const1 = new StatementNode("Const (1)");
        TreeNode const12 = new StatementNode("Const (1)");
        TreeNode repeat = new ExpNode("repeat");
        TreeNode write = new ExpNode("write");

        public Form1()
        {
            readX.AddSibling(if1);
            if1.AddChild(op1);
            if1.AddChild(assignFact);
            op1.AddChild(const0);
            op1.AddChild(idX);
            assignFact.AddChild(const12);
            assignFact.AddSibling(repeat);
            repeat.AddSibling(write);
            write.AddChild(idFact2);
            repeat.AddChild(assignFact2);
            assignFact2.AddChild(opMinus2);
            opMinus.AddChild(const1);
            opMinus.AddChild(idX3);
            assignFact2.AddChild(assignX);
            assignX.AddChild(opMinus);
            opMinus2.AddChild(idFact);
            opMinus2.AddChild(idX2);
            repeat.AddChild(opMinus3);
            opMinus3.AddChild(idX4);
            opMinus3.AddChild(const02);
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
            if(CodeText.Text != "")
            {
                Scanner scanner = new Scanner(CodeText.Text + " ");
                var tokens = scanner.getTokens();
                string tableText = "";
                foreach(Token token in tokens)
                {
                    tableText += token.Lexeme + "\t\t\t\t" + token.Type.ToString() + "\n";
                }
                //tableForm.SetTableText(tableText);
                //tableForm.Show();
                CodePanel.Visible = false;
                TreeText.Text = tableText;

                string errorString = "";
                foreach(string error in Error.getErrorList())
                {
                    errorString += error + "\n";
                }
                if(errorString.Length != 0)
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
