using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using TinyCompiler.Controller;
using TinyCompiler.Model;
using TinyCompiler.Model.Errors;

namespace TinyCompiler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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
                    tableText += token.Lexeme + "\t\t\t\t\t" + token.Type.ToString() + "\n";
                }

                CodePanel.Visible = false;
                TreeText.Text = tableText;

                string errorString = "";
                foreach (CompilationExpection error in CompilationExpection.getErrorList())
                {
                    if (error is TokenizationException)
                        errorString += error.Message + "\n";
                }
                if (errorString.Length != 0)
                {
                    ErrorText.Text = errorString;
                }
                else
                {
                    ErrorText.Text = "All Clear!";
                }
                CompilationExpection.clearErrorList();
            }
        }
        private void TT_button_Click(object sender, EventArgs e)
        {
            if (CodeText.Text != "")
            {
                Parser parser = new Parser(new Scanner(CodeText.Text + " ").getTokens());
                ParserTree parserTree = new ParserTree();
                Model.TreeNode treeNode = parser.parse();
                if (treeNode != null)
                {
                    parserTree.makeGraph(treeNode);
                    parserTree.showForm();
                }
                foreach (CompilationExpection error in CompilationExpection.getErrorList())
                {
                    if (error is TokenizationException)
                    {
                        MessageBox.Show("Fix Syntax Errors First", "Syntax Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else if (error is InvalidSyntaxException)
                    {
                        MessageBox.Show(error.Message, "Parsing Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                CompilationExpection.clearErrorList();
            }
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
    }
}