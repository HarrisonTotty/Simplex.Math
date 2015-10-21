namespace Simplex.Math.Debug
{
    partial class MainForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.initializationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operandInitializationTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationInitializationTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arithmeticTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplicationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TB = new System.Windows.Forms.RichTextBox();
            this.stringFormatTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalStringFormatTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializationTestsToolStripMenuItem,
            this.stringFormatTestsToolStripMenuItem,
            this.arithmeticTestsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(660, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // initializationTestsToolStripMenuItem
            // 
            this.initializationTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operandInitializationTestToolStripMenuItem,
            this.operationInitializationTestToolStripMenuItem});
            this.initializationTestsToolStripMenuItem.Name = "initializationTestsToolStripMenuItem";
            this.initializationTestsToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.initializationTestsToolStripMenuItem.Text = "Initialization Tests";
            // 
            // operandInitializationTestToolStripMenuItem
            // 
            this.operandInitializationTestToolStripMenuItem.Name = "operandInitializationTestToolStripMenuItem";
            this.operandInitializationTestToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.operandInitializationTestToolStripMenuItem.Text = "Operand Initialization Test";
            this.operandInitializationTestToolStripMenuItem.Click += new System.EventHandler(this.operandInitializationTestToolStripMenuItem_Click);
            // 
            // operationInitializationTestToolStripMenuItem
            // 
            this.operationInitializationTestToolStripMenuItem.Name = "operationInitializationTestToolStripMenuItem";
            this.operationInitializationTestToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.operationInitializationTestToolStripMenuItem.Text = "Operation Initialization Test";
            this.operationInitializationTestToolStripMenuItem.Click += new System.EventHandler(this.operationInitializationTestToolStripMenuItem_Click);
            // 
            // arithmeticTestsToolStripMenuItem
            // 
            this.arithmeticTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionTestsToolStripMenuItem,
            this.subtractionTestsToolStripMenuItem,
            this.multiplicationTestsToolStripMenuItem,
            this.divisionTestsToolStripMenuItem});
            this.arithmeticTestsToolStripMenuItem.Name = "arithmeticTestsToolStripMenuItem";
            this.arithmeticTestsToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.arithmeticTestsToolStripMenuItem.Text = "Arithmetic Tests";
            // 
            // additionTestsToolStripMenuItem
            // 
            this.additionTestsToolStripMenuItem.Name = "additionTestsToolStripMenuItem";
            this.additionTestsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.additionTestsToolStripMenuItem.Text = "Addition Tests";
            this.additionTestsToolStripMenuItem.Click += new System.EventHandler(this.additionTestsToolStripMenuItem_Click);
            // 
            // subtractionTestsToolStripMenuItem
            // 
            this.subtractionTestsToolStripMenuItem.Name = "subtractionTestsToolStripMenuItem";
            this.subtractionTestsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.subtractionTestsToolStripMenuItem.Text = "Subtraction Tests";
            // 
            // multiplicationTestsToolStripMenuItem
            // 
            this.multiplicationTestsToolStripMenuItem.Name = "multiplicationTestsToolStripMenuItem";
            this.multiplicationTestsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.multiplicationTestsToolStripMenuItem.Text = "Multiplication Tests";
            // 
            // divisionTestsToolStripMenuItem
            // 
            this.divisionTestsToolStripMenuItem.Name = "divisionTestsToolStripMenuItem";
            this.divisionTestsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.divisionTestsToolStripMenuItem.Text = "Division Tests";
            // 
            // TB
            // 
            this.TB.BackColor = System.Drawing.Color.White;
            this.TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB.Location = new System.Drawing.Point(0, 24);
            this.TB.Name = "TB";
            this.TB.ReadOnly = true;
            this.TB.Size = new System.Drawing.Size(660, 465);
            this.TB.TabIndex = 1;
            this.TB.Text = "";
            this.TB.WordWrap = false;
            this.TB.TextChanged += new System.EventHandler(this.TB_TextChanged);
            // 
            // stringFormatTestsToolStripMenuItem
            // 
            this.stringFormatTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalStringFormatTestToolStripMenuItem});
            this.stringFormatTestsToolStripMenuItem.Name = "stringFormatTestsToolStripMenuItem";
            this.stringFormatTestsToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.stringFormatTestsToolStripMenuItem.Text = "String Format Tests";
            // 
            // generalStringFormatTestToolStripMenuItem
            // 
            this.generalStringFormatTestToolStripMenuItem.Name = "generalStringFormatTestToolStripMenuItem";
            this.generalStringFormatTestToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.generalStringFormatTestToolStripMenuItem.Text = "General String Format Test";
            this.generalStringFormatTestToolStripMenuItem.Click += new System.EventHandler(this.generalStringFormatTestToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 489);
            this.Controls.Add(this.TB);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simplex Math Debug Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.RichTextBox TB;
        private System.Windows.Forms.ToolStripMenuItem initializationTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operandInitializationTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationInitializationTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arithmeticTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractionTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplicationTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divisionTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringFormatTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalStringFormatTestToolStripMenuItem;
    }
}

