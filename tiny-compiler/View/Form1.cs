using System;
using System.IO;
using System.Windows.Forms;
using TinyCompiler.Controller;
using TinyCompiler.Model;
using TinyCompiler.View;

namespace TinyCompiler
{
    public partial class Form1 : Form
    {
        TableForm tableForm;

        public Form1()
        {
            InitializeComponent();
            tableForm = new TableForm();
        }
        private void OpenFile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.OpenFile() != null)
                {
                    string fileText = File.ReadAllText(openFileDialog.FileName);
                    CodeText.Text = fileText;
                    Scanner s = new Scanner(fileText);
                }
            }
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Edit_button_Click(object sender, EventArgs e)
        {
            CodeText.ReadOnly = false;
            panel2.Visible = true;
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            //TODO: copy richTextBox1.Text into a temp file
            CodeText.ReadOnly = true;
        }

        private void TT_button_Click(object sender, EventArgs e)
        {
            if(CodeText.Text != "")
            {
                Scanner scanner = new Scanner(CodeText.Text);
                var tokens =  scanner.getTokens();
                string tableText = "";
                foreach (Token token in tokens)
                {
                    tableText += token.Lexeme + "\t\t" + token.Type.ToString() + "\n";
                }
                //tableForm.SetTableText(tableText);
                //tableForm.Show();
                panel2.Visible = false;
                richTextBox1.Text = tableText;
            }
        }
    }
}
