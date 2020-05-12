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
        TreeNode root = new ExpNode("1");
        TreeNode node2 = new ExpNode("2");
        TreeNode node3 = new ExpNode("3");
        TreeNode node4 = new StatementNode("4");
        TreeNode node5 = new StatementNode("5");
        TreeNode node6 = new StatementNode("6");
        TreeNode node7 = new StatementNode("7");
        public Form1()
        {
            root.AddChild(node2);
            root.AddChild(node3);
            node2.AddChild(node4);
            node2.AddChild(node5);
            node3.AddChild(node6);
            node3.AddChild(node7);
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

            parserTree.makeGraph(root);
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
            root.removeChild(new TreeNode("2"));
        }
    }
}
