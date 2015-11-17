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
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpGlobalScopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operandInitializationTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationInitializationTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionInitializationTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringFormatTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalStringFormatTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalityTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSOEqualityTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arithmeticTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplicationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicEvalutationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TB = new System.Windows.Forms.RichTextBox();
            this.groupingTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reduceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.factorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.initializationTestsToolStripMenuItem,
            this.stringFormatTestsToolStripMenuItem,
            this.equalityTestsToolStripMenuItem,
            this.arithmeticTestsToolStripMenuItem,
            this.functionTestsToolStripMenuItem,
            this.groupingTestsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(863, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dumpGlobalScopeToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // dumpGlobalScopeToolStripMenuItem
            // 
            this.dumpGlobalScopeToolStripMenuItem.Name = "dumpGlobalScopeToolStripMenuItem";
            this.dumpGlobalScopeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.dumpGlobalScopeToolStripMenuItem.Text = "Dump Global Scope";
            this.dumpGlobalScopeToolStripMenuItem.Click += new System.EventHandler(this.dumpGlobalScopeToolStripMenuItem_Click);
            // 
            // initializationTestsToolStripMenuItem
            // 
            this.initializationTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operandInitializationTestToolStripMenuItem,
            this.operationInitializationTestToolStripMenuItem,
            this.functionInitializationTestToolStripMenuItem});
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
            // functionInitializationTestToolStripMenuItem
            // 
            this.functionInitializationTestToolStripMenuItem.Name = "functionInitializationTestToolStripMenuItem";
            this.functionInitializationTestToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.functionInitializationTestToolStripMenuItem.Text = "Function Initialization Test";
            this.functionInitializationTestToolStripMenuItem.Click += new System.EventHandler(this.functionInitializationTestToolStripMenuItem_Click);
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
            // equalityTestsToolStripMenuItem
            // 
            this.equalityTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operandsToolStripMenuItem,
            this.binaryOperationsToolStripMenuItem,
            this.cSOEqualityTestToolStripMenuItem});
            this.equalityTestsToolStripMenuItem.Name = "equalityTestsToolStripMenuItem";
            this.equalityTestsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.equalityTestsToolStripMenuItem.Text = "Equality Tests";
            // 
            // operandsToolStripMenuItem
            // 
            this.operandsToolStripMenuItem.Name = "operandsToolStripMenuItem";
            this.operandsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.operandsToolStripMenuItem.Text = "Operands";
            this.operandsToolStripMenuItem.Click += new System.EventHandler(this.operandsToolStripMenuItem_Click);
            // 
            // binaryOperationsToolStripMenuItem
            // 
            this.binaryOperationsToolStripMenuItem.Name = "binaryOperationsToolStripMenuItem";
            this.binaryOperationsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.binaryOperationsToolStripMenuItem.Text = "BinaryOperations";
            this.binaryOperationsToolStripMenuItem.Click += new System.EventHandler(this.binaryOperationsToolStripMenuItem_Click);
            // 
            // cSOEqualityTestToolStripMenuItem
            // 
            this.cSOEqualityTestToolStripMenuItem.Name = "cSOEqualityTestToolStripMenuItem";
            this.cSOEqualityTestToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cSOEqualityTestToolStripMenuItem.Text = "CSO Equality Test";
            this.cSOEqualityTestToolStripMenuItem.Click += new System.EventHandler(this.cSOEqualityTestToolStripMenuItem_Click);
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
            this.subtractionTestsToolStripMenuItem.Click += new System.EventHandler(this.subtractionTestsToolStripMenuItem_Click);
            // 
            // multiplicationTestsToolStripMenuItem
            // 
            this.multiplicationTestsToolStripMenuItem.Name = "multiplicationTestsToolStripMenuItem";
            this.multiplicationTestsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.multiplicationTestsToolStripMenuItem.Text = "Multiplication Tests";
            this.multiplicationTestsToolStripMenuItem.Click += new System.EventHandler(this.multiplicationTestsToolStripMenuItem_Click);
            // 
            // divisionTestsToolStripMenuItem
            // 
            this.divisionTestsToolStripMenuItem.Name = "divisionTestsToolStripMenuItem";
            this.divisionTestsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.divisionTestsToolStripMenuItem.Text = "Division Tests";
            this.divisionTestsToolStripMenuItem.Click += new System.EventHandler(this.divisionTestsToolStripMenuItem_Click);
            // 
            // functionTestsToolStripMenuItem
            // 
            this.functionTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basicEvalutationTestsToolStripMenuItem});
            this.functionTestsToolStripMenuItem.Name = "functionTestsToolStripMenuItem";
            this.functionTestsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.functionTestsToolStripMenuItem.Text = "Function Tests";
            // 
            // basicEvalutationTestsToolStripMenuItem
            // 
            this.basicEvalutationTestsToolStripMenuItem.Name = "basicEvalutationTestsToolStripMenuItem";
            this.basicEvalutationTestsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.basicEvalutationTestsToolStripMenuItem.Text = "Basic Evalutation Tests";
            this.basicEvalutationTestsToolStripMenuItem.Click += new System.EventHandler(this.basicEvalutationTestsToolStripMenuItem_Click);
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
            this.TB.Size = new System.Drawing.Size(863, 465);
            this.TB.TabIndex = 1;
            this.TB.Text = "";
            this.TB.WordWrap = false;
            this.TB.TextChanged += new System.EventHandler(this.TB_TextChanged);
            // 
            // groupingTestsToolStripMenuItem
            // 
            this.groupingTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simplifyToolStripMenuItem,
            this.reduceToolStripMenuItem,
            this.expandToolStripMenuItem,
            this.factorToolStripMenuItem});
            this.groupingTestsToolStripMenuItem.Name = "groupingTestsToolStripMenuItem";
            this.groupingTestsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.groupingTestsToolStripMenuItem.Text = "Grouping Tests";
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            // 
            // reduceToolStripMenuItem
            // 
            this.reduceToolStripMenuItem.Name = "reduceToolStripMenuItem";
            this.reduceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reduceToolStripMenuItem.Text = "Reduce";
            // 
            // factorToolStripMenuItem
            // 
            this.factorToolStripMenuItem.Name = "factorToolStripMenuItem";
            this.factorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.factorToolStripMenuItem.Text = "Factor";
            // 
            // simplifyToolStripMenuItem
            // 
            this.simplifyToolStripMenuItem.Name = "simplifyToolStripMenuItem";
            this.simplifyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.simplifyToolStripMenuItem.Text = "Simplify";
            this.simplifyToolStripMenuItem.Click += new System.EventHandler(this.simplifyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 489);
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
        private System.Windows.Forms.ToolStripMenuItem equalityTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binaryOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSOEqualityTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpGlobalScopeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionInitializationTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicEvalutationTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupingTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reduceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplifyToolStripMenuItem;
    }
}

