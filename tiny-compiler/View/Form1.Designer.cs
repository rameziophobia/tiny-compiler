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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainContainer = new System.Windows.Forms.SplitContainer();
            this.MainMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.OpenFile_button = new System.Windows.Forms.Button();
            this.Edit_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.LA_button = new System.Windows.Forms.Button();
            this.TT_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.rmv2subTree = new System.Windows.Forms.Button();
            this.SubContainer = new System.Windows.Forms.SplitContainer();
            this.TreePanel = new System.Windows.Forms.Panel();
            this.CodePanel = new System.Windows.Forms.Panel();
            this.CodeText = new System.Windows.Forms.RichTextBox();
            this.TreeText = new System.Windows.Forms.RichTextBox();
            this.ErrorText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).BeginInit();
            this.MainContainer.Panel1.SuspendLayout();
            this.MainContainer.Panel2.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubContainer)).BeginInit();
            this.SubContainer.Panel1.SuspendLayout();
            this.SubContainer.Panel2.SuspendLayout();
            this.SubContainer.SuspendLayout();
            this.TreePanel.SuspendLayout();
            this.CodePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "tny";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Title = "Open a Tiny file";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Save .tny File";
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.IsSplitterFixed = true;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Margin = new System.Windows.Forms.Padding(2);
            this.MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            this.MainContainer.Panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.MainContainer.Panel1.Controls.Add(this.MainMenu);
            // 
            // MainContainer.Panel2
            // 
            this.MainContainer.Panel2.Controls.Add(this.SubContainer);
            this.MainContainer.Size = new System.Drawing.Size(620, 449);
            this.MainContainer.SplitterDistance = 175;
            this.MainContainer.SplitterWidth = 3;
            this.MainContainer.TabIndex = 0;
            this.MainContainer.TabStop = false;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Snow;
            this.MainMenu.Controls.Add(this.OpenFile_button);
            this.MainMenu.Controls.Add(this.Edit_button);
            this.MainMenu.Controls.Add(this.Save_button);
            this.MainMenu.Controls.Add(this.LA_button);
            this.MainMenu.Controls.Add(this.TT_button);
            this.MainMenu.Controls.Add(this.Exit_button);
            this.MainMenu.Controls.Add(this.rmv2subTree);
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Margin = new System.Windows.Forms.Padding(2);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(4, 8, 0, 0);
            this.MainMenu.Size = new System.Drawing.Size(175, 449);
            this.MainMenu.TabIndex = 0;
            // 
            // OpenFile_button
            // 
            this.OpenFile_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFile_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OpenFile_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OpenFile_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.OpenFile_button.FlatAppearance.BorderSize = 0;
            this.OpenFile_button.Location = new System.Drawing.Point(6, 10);
            this.OpenFile_button.Margin = new System.Windows.Forms.Padding(2);
            this.OpenFile_button.Name = "OpenFile_button";
            this.OpenFile_button.Size = new System.Drawing.Size(161, 63);
            this.OpenFile_button.TabIndex = 1;
            this.OpenFile_button.Text = "&Open File";
            this.OpenFile_button.UseVisualStyleBackColor = false;
            this.OpenFile_button.Click += new System.EventHandler(this.OpenFile_button_Click);
            // 
            // Edit_button
            // 
            this.Edit_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Edit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Edit_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Edit_button.FlatAppearance.BorderSize = 0;
            this.Edit_button.Location = new System.Drawing.Point(6, 77);
            this.Edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.Edit_button.Name = "Edit_button";
            this.Edit_button.Size = new System.Drawing.Size(161, 63);
            this.Edit_button.TabIndex = 2;
            this.Edit_button.Text = "&Edit";
            this.Edit_button.UseVisualStyleBackColor = false;
            this.Edit_button.Click += new System.EventHandler(this.Edit_button_Click);
            // 
            // Save_button
            // 
            this.Save_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Save_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Save_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Save_button.FlatAppearance.BorderSize = 0;
            this.Save_button.Location = new System.Drawing.Point(6, 144);
            this.Save_button.Margin = new System.Windows.Forms.Padding(2);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(161, 63);
            this.Save_button.TabIndex = 3;
            this.Save_button.Text = "&Save As";
            this.Save_button.UseVisualStyleBackColor = false;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // LA_button
            // 
            this.LA_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LA_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LA_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LA_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.LA_button.FlatAppearance.BorderSize = 0;
            this.LA_button.Location = new System.Drawing.Point(6, 211);
            this.LA_button.Margin = new System.Windows.Forms.Padding(2);
            this.LA_button.Name = "LA_button";
            this.LA_button.Size = new System.Drawing.Size(161, 63);
            this.LA_button.TabIndex = 4;
            this.LA_button.Text = "Lexeme &Analysis";
            this.LA_button.UseVisualStyleBackColor = false;
            this.LA_button.Click += new System.EventHandler(this.LA_button_Click);
            // 
            // TT_button
            // 
            this.TT_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TT_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TT_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TT_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.TT_button.FlatAppearance.BorderSize = 0;
            this.TT_button.Location = new System.Drawing.Point(6, 278);
            this.TT_button.Margin = new System.Windows.Forms.Padding(2);
            this.TT_button.Name = "TT_button";
            this.TT_button.Size = new System.Drawing.Size(161, 63);
            this.TT_button.TabIndex = 5;
            this.TT_button.Text = "&Syntax Tree";
            this.TT_button.UseVisualStyleBackColor = false;
            this.TT_button.Click += new System.EventHandler(this.TT_button_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Exit_button.Location = new System.Drawing.Point(6, 345);
            this.Exit_button.Margin = new System.Windows.Forms.Padding(2);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(52, 34);
            this.Exit_button.TabIndex = 7;
            this.Exit_button.Text = "E&xit";
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // rmv2subTree
            // 
            this.rmv2subTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rmv2subTree.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rmv2subTree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rmv2subTree.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.rmv2subTree.FlatAppearance.BorderSize = 0;
            this.rmv2subTree.Location = new System.Drawing.Point(6, 383);
            this.rmv2subTree.Margin = new System.Windows.Forms.Padding(2);
            this.rmv2subTree.Name = "rmv2subTree";
            this.rmv2subTree.Size = new System.Drawing.Size(161, 63);
            this.rmv2subTree.TabIndex = 8;
            this.rmv2subTree.Text = "(&Test)\r\nRemove 2 Sub Tee";
            this.rmv2subTree.UseVisualStyleBackColor = false;
            this.rmv2subTree.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubContainer
            // 
            this.SubContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SubContainer.Location = new System.Drawing.Point(0, 0);
            this.SubContainer.Margin = new System.Windows.Forms.Padding(2);
            this.SubContainer.Name = "SubContainer";
            this.SubContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SubContainer.Panel1
            // 
            this.SubContainer.Panel1.Controls.Add(this.TreePanel);
            // 
            // SubContainer.Panel2
            // 
            this.SubContainer.Panel2.Controls.Add(this.ErrorText);
            this.SubContainer.Size = new System.Drawing.Size(442, 449);
            this.SubContainer.SplitterDistance = 320;
            this.SubContainer.SplitterWidth = 3;
            this.SubContainer.TabIndex = 0;
            // 
            // TreePanel
            // 
            this.TreePanel.Controls.Add(this.CodePanel);
            this.TreePanel.Controls.Add(this.TreeText);
            this.TreePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreePanel.Location = new System.Drawing.Point(0, 0);
            this.TreePanel.Margin = new System.Windows.Forms.Padding(2);
            this.TreePanel.Name = "TreePanel";
            this.TreePanel.Size = new System.Drawing.Size(442, 320);
            this.TreePanel.TabIndex = 0;
            // 
            // CodePanel
            // 
            this.CodePanel.Controls.Add(this.CodeText);
            this.CodePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodePanel.Location = new System.Drawing.Point(0, 0);
            this.CodePanel.Margin = new System.Windows.Forms.Padding(2);
            this.CodePanel.Name = "CodePanel";
            this.CodePanel.Size = new System.Drawing.Size(442, 320);
            this.CodePanel.TabIndex = 1;
            // 
            // CodeText
            // 
            this.CodeText.AcceptsTab = true;
            this.CodeText.BackColor = System.Drawing.Color.Black;
            this.CodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeText.ForeColor = System.Drawing.Color.White;
            this.CodeText.Location = new System.Drawing.Point(0, 0);
            this.CodeText.Margin = new System.Windows.Forms.Padding(2);
            this.CodeText.Name = "CodeText";
            this.CodeText.Size = new System.Drawing.Size(442, 320);
            this.CodeText.TabIndex = 0;
            this.CodeText.TabStop = false;
            this.CodeText.Text = "";
            // 
            // TreeText
            // 
            this.TreeText.BackColor = System.Drawing.Color.Black;
            this.TreeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.TreeText.ForeColor = System.Drawing.Color.White;
            this.TreeText.Location = new System.Drawing.Point(0, 0);
            this.TreeText.Margin = new System.Windows.Forms.Padding(2);
            this.TreeText.Name = "TreeText";
            this.TreeText.ReadOnly = true;
            this.TreeText.Size = new System.Drawing.Size(442, 320);
            this.TreeText.TabIndex = 0;
            this.TreeText.TabStop = false;
            this.TreeText.Text = "";
            // 
            // ErrorText
            // 
            this.ErrorText.BackColor = System.Drawing.Color.GhostWhite;
            this.ErrorText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorText.ForeColor = System.Drawing.Color.Crimson;
            this.ErrorText.Location = new System.Drawing.Point(0, 0);
            this.ErrorText.Margin = new System.Windows.Forms.Padding(2);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.ReadOnly = true;
            this.ErrorText.Size = new System.Drawing.Size(442, 126);
            this.ErrorText.TabIndex = 0;
            this.ErrorText.TabStop = false;
            this.ErrorText.Text = "All Clear!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(620, 449);
            this.Controls.Add(this.MainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Compiler";
            this.MainContainer.Panel1.ResumeLayout(false);
            this.MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainContainer)).EndInit();
            this.MainContainer.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.SubContainer.Panel1.ResumeLayout(false);
            this.SubContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubContainer)).EndInit();
            this.SubContainer.ResumeLayout(false);
            this.TreePanel.ResumeLayout(false);
            this.CodePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SplitContainer MainContainer;
        private System.Windows.Forms.RichTextBox TreeText;
        private System.Windows.Forms.FlowLayoutPanel MainMenu;
        private System.Windows.Forms.Button OpenFile_button;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button LA_button;
        private System.Windows.Forms.Button TT_button;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.RichTextBox ErrorText;
        private System.Windows.Forms.RichTextBox CodeText;
        private System.Windows.Forms.SplitContainer SubContainer;
        private System.Windows.Forms.Panel TreePanel;
        private System.Windows.Forms.Panel CodePanel;
        private System.Windows.Forms.Button Edit_button;
        private System.Windows.Forms.Button rmv2subTree;
    }
}

