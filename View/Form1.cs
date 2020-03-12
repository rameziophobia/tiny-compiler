using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyCompiler.Controller;

namespace TinyCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            //TODO: copy richTextBox1.Text into a temp file
            CodeText.ReadOnly = true;
        }
    }
}
