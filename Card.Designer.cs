namespace DolinskSportSchool
{
    partial class Card
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
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CanceleBtn = new System.Windows.Forms.Button();
            this.EditorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorPanel
            // 
            this.EditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EditorPanel.Controls.Add(this.CanceleBtn);
            this.EditorPanel.Controls.Add(this.SaveBtn);
            this.EditorPanel.Location = new System.Drawing.Point(5, 3);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(1071, 237);
            this.EditorPanel.TabIndex = 0;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(323, 182);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(102, 28);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CanceleBtn
            // 
            this.CanceleBtn.Location = new System.Drawing.Point(527, 182);
            this.CanceleBtn.Name = "CanceleBtn";
            this.CanceleBtn.Size = new System.Drawing.Size(102, 28);
            this.CanceleBtn.TabIndex = 1;
            this.CanceleBtn.Text = "Отменить";
            this.CanceleBtn.UseVisualStyleBackColor = true;
            this.CanceleBtn.Click += new System.EventHandler(this.CanceleBtn_Click);
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 243);
            this.Controls.Add(this.EditorPanel);
            this.Name = "Card";
            this.Text = "Card";
            this.EditorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.Button CanceleBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}