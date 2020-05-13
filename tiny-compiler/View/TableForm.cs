using System;
using System.Windows.Forms;

namespace TinyCompiler.View
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {

        }

        public void SetTableText(string text)
        {
            textBox1.Text = text;
        }
    }
}
