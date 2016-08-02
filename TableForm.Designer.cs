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
            this.DBGrid = new System.Windows.Forms.DataGridView();
            this.SelectionFilter = new System.Windows.Forms.Panel();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.ModifyPanel = new System.Windows.Forms.Panel();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).BeginInit();
            this.SelectionFilter.SuspendLayout();
            this.ModifyPanel.SuspendLayout();
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
            this.DBGrid.Location = new System.Drawing.Point(-1, -4);
            this.DBGrid.Name = "DBGrid";
            this.DBGrid.ReadOnly = true;
            this.DBGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBGrid.Size = new System.Drawing.Size(1349, 287);
            this.DBGrid.TabIndex = 0;
            // 
            // SelectionFilter
            // 
            this.SelectionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectionFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SelectionFilter.Controls.Add(this.AcceptBtn);
            this.SelectionFilter.Location = new System.Drawing.Point(-1, 538);
            this.SelectionFilter.Name = "SelectionFilter";
            this.SelectionFilter.Size = new System.Drawing.Size(113, 252);
            this.SelectionFilter.TabIndex = 1;
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(3, 223);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(103, 23);
            this.AcceptBtn.TabIndex = 0;
            this.AcceptBtn.Text = "Отфильтровать";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FilterPanel.Location = new System.Drawing.Point(118, 538);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(1230, 252);
            this.FilterPanel.TabIndex = 2;
            // 
            // ModifyPanel
            // 
            this.ModifyPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModifyPanel.Controls.Add(this.EditBtn);
            this.ModifyPanel.Controls.Add(this.AddBtn);
            this.ModifyPanel.Location = new System.Drawing.Point(4, 289);
            this.ModifyPanel.Name = "ModifyPanel";
            this.ModifyPanel.Size = new System.Drawing.Size(108, 243);
            this.ModifyPanel.TabIndex = 3;
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(6, 59);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(95, 34);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Редактировать";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(6, 19);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(95, 34);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Добавить запись";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 794);
            this.Controls.Add(this.ModifyPanel);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.SelectionFilter);
            this.Controls.Add(this.DBGrid);
            this.Name = "TableForm";
            this.Text = "TableForm";
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).EndInit();
            this.SelectionFilter.ResumeLayout(false);
            this.ModifyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DBGrid;
        private System.Windows.Forms.Panel SelectionFilter;
        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Panel ModifyPanel;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button EditBtn;
    }
}