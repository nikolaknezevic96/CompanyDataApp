namespace CompanyDataApp
{
    partial class SymbolsForm
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
            this.TypeCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExchangeCmb = new System.Windows.Forms.ComboBox();
            this.AddSymbolBtn = new System.Windows.Forms.Button();
            this.EditSymbolBtn = new System.Windows.Forms.Button();
            this.DeleteSymbolBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.database1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filterBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TypeCmb
            // 
            this.TypeCmb.FormattingEnabled = true;
            this.TypeCmb.Location = new System.Drawing.Point(111, 61);
            this.TypeCmb.Name = "TypeCmb";
            this.TypeCmb.Size = new System.Drawing.Size(121, 24);
            this.TypeCmb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type filter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Exchange filter:";
            // 
            // ExchangeCmb
            // 
            this.ExchangeCmb.FormattingEnabled = true;
            this.ExchangeCmb.Location = new System.Drawing.Point(377, 61);
            this.ExchangeCmb.Name = "ExchangeCmb";
            this.ExchangeCmb.Size = new System.Drawing.Size(121, 24);
            this.ExchangeCmb.TabIndex = 5;
            // 
            // AddSymbolBtn
            // 
            this.AddSymbolBtn.Location = new System.Drawing.Point(666, 104);
            this.AddSymbolBtn.Name = "AddSymbolBtn";
            this.AddSymbolBtn.Size = new System.Drawing.Size(124, 45);
            this.AddSymbolBtn.TabIndex = 7;
            this.AddSymbolBtn.Text = "Add symbol";
            this.AddSymbolBtn.UseVisualStyleBackColor = true;
            this.AddSymbolBtn.Click += new System.EventHandler(this.AddSymbolBtn_Click);
            // 
            // EditSymbolBtn
            // 
            this.EditSymbolBtn.Location = new System.Drawing.Point(666, 181);
            this.EditSymbolBtn.Name = "EditSymbolBtn";
            this.EditSymbolBtn.Size = new System.Drawing.Size(124, 57);
            this.EditSymbolBtn.TabIndex = 8;
            this.EditSymbolBtn.Text = "View/Edit symbol";
            this.EditSymbolBtn.UseVisualStyleBackColor = true;
            this.EditSymbolBtn.Click += new System.EventHandler(this.EditSymbolBtn_Click);
            // 
            // DeleteSymbolBtn
            // 
            this.DeleteSymbolBtn.Location = new System.Drawing.Point(666, 286);
            this.DeleteSymbolBtn.Name = "DeleteSymbolBtn";
            this.DeleteSymbolBtn.Size = new System.Drawing.Size(124, 65);
            this.DeleteSymbolBtn.TabIndex = 9;
            this.DeleteSymbolBtn.Text = "Delete symbol";
            this.DeleteSymbolBtn.UseVisualStyleBackColor = true;
            this.DeleteSymbolBtn.Click += new System.EventHandler(this.DeleteSymbolBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(666, 424);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(124, 64);
            this.CloseBtn.TabIndex = 10;
            this.CloseBtn.Text = "Form close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.database1ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 24);
            this.toolStripMenuItem2.Text = "Select the database:";
            // 
            // database1ToolStripMenuItem
            // 
            this.database1ToolStripMenuItem.Name = "database1ToolStripMenuItem";
            this.database1ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.database1ToolStripMenuItem.Text = "Database 1";
            this.database1ToolStripMenuItem.Click += new System.EventHandler(this.Database1ToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(566, 384);
            this.dataGridView1.TabIndex = 12;
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(524, 61);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(75, 23);
            this.filterBtn.TabIndex = 13;
            this.filterBtn.Text = "Filter";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // SymbolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 580);
            this.Controls.Add(this.filterBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.DeleteSymbolBtn);
            this.Controls.Add(this.EditSymbolBtn);
            this.Controls.Add(this.AddSymbolBtn);
            this.Controls.Add(this.ExchangeCmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeCmb);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SymbolsForm";
            this.Text = "Symbols";
            this.Load += new System.EventHandler(this.SymbolsForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox TypeCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ExchangeCmb;
        private System.Windows.Forms.Button AddSymbolBtn;
        private System.Windows.Forms.Button EditSymbolBtn;
        private System.Windows.Forms.Button DeleteSymbolBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem database1ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button filterBtn;
    }
}