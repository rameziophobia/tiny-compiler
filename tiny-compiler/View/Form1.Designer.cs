namespace TinyCompiler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Exit_button = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.TT_button = new System.Windows.Forms.Button();
            this.LA_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.Edit_button = new System.Windows.Forms.Button();
            this.OpenFile_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CodeText = new System.Windows.Forms.RichTextBox();
            this.ErrorText = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.splitContainer1.Panel1.Controls.Add(this.Exit_button);
            this.splitContainer1.Panel1.Controls.Add(this.button6);
            this.splitContainer1.Panel1.Controls.Add(this.TT_button);
            this.splitContainer1.Panel1.Controls.Add(this.LA_button);
            this.splitContainer1.Panel1.Controls.Add(this.Save_button);
            this.splitContainer1.Panel1.Controls.Add(this.Edit_button);
            this.splitContainer1.Panel1.Controls.Add(this.OpenFile_button);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(620, 470);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // Exit_button
            // 
            this.Exit_button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Exit_button.BackColor = System.Drawing.Color.DarkKhaki;
            this.Exit_button.Location = new System.Drawing.Point(120, 410);
            this.Exit_button.Margin = new System.Windows.Forms.Padding(2);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(52, 34);
            this.Exit_button.TabIndex = 6;
            this.Exit_button.Text = "E&xit";
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.DarkKhaki;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.Location = new System.Drawing.Point(9, 342);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 63);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // TT_button
            // 
            this.TT_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TT_button.BackColor = System.Drawing.Color.DarkKhaki;
            this.TT_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TT_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.TT_button.FlatAppearance.BorderSize = 0;
            this.TT_button.Location = new System.Drawing.Point(9, 275);
            this.TT_button.Margin = new System.Windows.Forms.Padding(2);
            this.TT_button.Name = "TT_button";
            this.TT_button.Size = new System.Drawing.Size(162, 63);
            this.TT_button.TabIndex = 4;
            this.TT_button.Text = "&Token Tree";
            this.TT_button.UseVisualStyleBackColor = false;
            this.TT_button.Click += new System.EventHandler(this.TT_button_Click);
            // 
            // LA_button
            // 
            this.LA_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LA_button.BackColor = System.Drawing.Color.DarkKhaki;
            this.LA_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LA_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.LA_button.FlatAppearance.BorderSize = 0;
            this.LA_button.Location = new System.Drawing.Point(9, 207);
            this.LA_button.Margin = new System.Windows.Forms.Padding(2);
            this.LA_button.Name = "LA_button";
            this.LA_button.Size = new System.Drawing.Size(162, 63);
            this.LA_button.TabIndex = 3;
            this.LA_button.Text = "Lexeme &Analysis";
            this.LA_button.UseVisualStyleBackColor = false;
            // 
            // Save_button
            // 
            this.Save_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_button.BackColor = System.Drawing.Color.DarkKhaki;
            this.Save_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Save_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Save_button.FlatAppearance.BorderSize = 0;
            this.Save_button.Location = new System.Drawing.Point(9, 140);
            this.Save_button.Margin = new System.Windows.Forms.Padding(2);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(162, 63);
            this.Save_button.TabIndex = 2;
            this.Save_button.Text = "&Save";
            this.Save_button.UseVisualStyleBackColor = false;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_button.BackColor = System.Drawing.Color.DarkKhaki;
            this.Edit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Edit_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Edit_button.FlatAppearance.BorderSize = 0;
            this.Edit_button.Location = new System.Drawing.Point(9, 72);
            this.Edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(162, 63);
            this.Edit_button.TabIndex = 1;
            this.Edit_button.Text = "&Edit";
            this.Edit_button.UseVisualStyleBackColor = false;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // OpenFile_button
            // 
            this.OpenFile_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFile_button.BackColor = System.Drawing.Color.DarkKhaki;
            this.OpenFile_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OpenFile_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.OpenFile_button.FlatAppearance.BorderSize = 0;
            this.OpenFile_button.Location = new System.Drawing.Point(9, 5);
            this.OpenFile_button.Margin = new System.Windows.Forms.Padding(2);
            this.OpenFile_button.Name = "OpenFile_button";
            this.OpenFile_button.Size = new System.Drawing.Size(162, 63);
            this.OpenFile_button.TabIndex = 0;
            this.OpenFile_button.Text = "&Open File";
            this.OpenFile_button.UseVisualStyleBackColor = false;
            this.OpenFile_button.Click += new System.EventHandler(this.OpenFile_button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CodeText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ErrorText, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.47552F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.52448F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CodeText
            // 
            this.CodeText.BackColor = System.Drawing.Color.Black;
            this.CodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeText.ForeColor = System.Drawing.Color.White;
            this.CodeText.Location = new System.Drawing.Point(2, 2);
            this.CodeText.Margin = new System.Windows.Forms.Padding(2);
            this.CodeText.Name = "CodeText";
            this.CodeText.ReadOnly = true;
            this.CodeText.Size = new System.Drawing.Size(434, 342);
            this.CodeText.TabIndex = 0;
            this.CodeText.Text = "";
            // 
            // ErrorText
            // 
            this.ErrorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.ErrorText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(154)))), ((int)(((byte)(116)))));
            this.ErrorText.Location = new System.Drawing.Point(2, 348);
            this.ErrorText.Margin = new System.Windows.Forms.Padding(2);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.ReadOnly = true;
            this.ErrorText.Size = new System.Drawing.Size(434, 115);
            this.ErrorText.TabIndex = 1;
            this.ErrorText.Text = "All Clear!";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "\"txt files (*.txt)|*.txt|All files (*.*)|*.*\"";
            this.openFileDialog.Title = "Open a Tiny file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 470);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Compiler";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox CodeText;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button TT_button;
        private System.Windows.Forms.Button LA_button;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.Button OpenFile_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RichTextBox ErrorText;
    }
}

