namespace DolinskSportSchool
{
    partial class TableForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.DBGrid = new System.Windows.Forms.DataGridView();
            this.DBGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectionFilter = new System.Windows.Forms.Panel();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.ModifyPanel = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ColumnViewPanel = new System.Windows.Forms.Panel();
            this.Stats = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MTable = new System.Windows.Forms.ToolStripMenuItem();
            this.MTableDuplicates = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).BeginInit();
            this.DBGridMenu.SuspendLayout();
            this.SelectionFilter.SuspendLayout();
            this.ModifyPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBGrid
            // 
            this.DBGrid.AllowUserToAddRows = false;
            this.DBGrid.AllowUserToDeleteRows = false;
            this.DBGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGrid.ContextMenuStrip = this.DBGridMenu;
            this.DBGrid.Location = new System.Drawing.Point(-1, 30);
            this.DBGrid.Name = "DBGrid";
            this.DBGrid.ReadOnly = true;
            this.DBGrid.RowHeadersVisible = false;
            this.DBGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBGrid.Size = new System.Drawing.Size(1349, 362);
            this.DBGrid.TabIndex = 0;
            this.DBGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGrid_DoubleClick);
            this.DBGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.HeaderClick);
            // 
            // DBGridMenu
            // 
            this.DBGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.DBGridMenu.Name = "DBGridMenu";
            this.DBGridMenu.Size = new System.Drawing.Size(140, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyToolStripMenuItem.Text = "Копировать";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // SelectionFilter
            // 
            this.SelectionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectionFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectionFilter.Controls.Add(this.AcceptBtn);
            this.SelectionFilter.Location = new System.Drawing.Point(-1, 538);
            this.SelectionFilter.Name = "SelectionFilter";
            this.SelectionFilter.Size = new System.Drawing.Size(134, 252);
            this.SelectionFilter.TabIndex = 1;
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AcceptBtn.Location = new System.Drawing.Point(5, 188);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(124, 30);
            this.AcceptBtn.TabIndex = 0;
            this.AcceptBtn.Text = "Отфильтровать";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilterPanel.AutoScroll = true;
            this.FilterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterPanel.Location = new System.Drawing.Point(139, 538);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(960, 252);
            this.FilterPanel.TabIndex = 2;
            // 
            // ModifyPanel
            // 
            this.ModifyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModifyPanel.Controls.Add(this.DeleteBtn);
            this.ModifyPanel.Controls.Add(this.EditBtn);
            this.ModifyPanel.Controls.Add(this.AddBtn);
            this.ModifyPanel.Location = new System.Drawing.Point(4, 484);
            this.ModifyPanel.Name = "ModifyPanel";
            this.ModifyPanel.Size = new System.Drawing.Size(385, 52);
            this.ModifyPanel.TabIndex = 3;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBtn.Location = new System.Drawing.Point(6, 12);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(95, 34);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditBtn.Location = new System.Drawing.Point(107, 12);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(125, 34);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Редактировать";
            this.EditBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.AddBtn.Location = new System.Drawing.Point(238, 12);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(133, 34);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Добавить запись";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ColumnViewPanel
            // 
            this.ColumnViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColumnViewPanel.AutoScroll = true;
            this.ColumnViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColumnViewPanel.Location = new System.Drawing.Point(1105, 484);
            this.ColumnViewPanel.Name = "ColumnViewPanel";
            this.ColumnViewPanel.Size = new System.Drawing.Size(243, 306);
            this.ColumnViewPanel.TabIndex = 4;
            // 
            // Stats
            // 
            this.Stats.AutoSize = true;
            this.Stats.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stats.Location = new System.Drawing.Point(2, 395);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(143, 21);
            this.Stats.TabIndex = 5;
            this.Stats.Text = "Кол-во записей: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MTable});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1348, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MTable
            // 
            this.MTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MTableDuplicates});
            this.MTable.Name = "MTable";
            this.MTable.Size = new System.Drawing.Size(66, 20);
            this.MTable.Text = "Таблица";
            // 
            // MTableDuplicates
            // 
            this.MTableDuplicates.Name = "MTableDuplicates";
            this.MTableDuplicates.Size = new System.Drawing.Size(188, 22);
            this.MTableDuplicates.Text = "Показать Дубликаты";
            this.MTableDuplicates.Click += new System.EventHandler(this.MTableDuplicates_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 794);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.ColumnViewPanel);
            this.Controls.Add(this.ModifyPanel);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.SelectionFilter);
            this.Controls.Add(this.DBGrid);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseTable);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).EndInit();
            this.DBGridMenu.ResumeLayout(false);
            this.SelectionFilter.ResumeLayout(false);
            this.ModifyPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DBGrid;
        private System.Windows.Forms.Panel SelectionFilter;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Panel ModifyPanel;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Panel ColumnViewPanel;
        private System.Windows.Forms.Label Stats;
        private System.Windows.Forms.ToolStripMenuItem MTable;
        private System.Windows.Forms.ToolStripMenuItem MTableDuplicates;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip DBGridMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}