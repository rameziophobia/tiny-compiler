﻿using System;
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

        public Form1()
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
            Parser parser = new Parser(new Scanner(CodeText.Text + " ").getTokens()) ;

            parserTree.makeGraph(parser.parse());
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
