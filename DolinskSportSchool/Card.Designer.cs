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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card));
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.CanceleBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.EditorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorPanel
            // 
            this.EditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPanel.Controls.Add(this.CanceleBtn);
            this.EditorPanel.Controls.Add(this.SaveBtn);
            this.EditorPanel.Location = new System.Drawing.Point(5, 3);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(1115, 197);
            this.EditorPanel.TabIndex = 0;
            // 
            // CanceleBtn
            // 
            this.CanceleBtn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CanceleBtn.Location = new System.Drawing.Point(636, 148);
            this.CanceleBtn.Name = "CanceleBtn";
            this.CanceleBtn.Size = new System.Drawing.Size(102, 28);
            this.CanceleBtn.TabIndex = 1;
            this.CanceleBtn.Text = "Отменить";
            this.CanceleBtn.UseVisualStyleBackColor = true;
            this.CanceleBtn.Click += new System.EventHandler(this.CanceleBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBtn.Location = new System.Drawing.Point(439, 148);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(102, 28);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 203);
            this.Controls.Add(this.EditorPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Card";
            this.Text = "Card";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseCard);
            this.ResizeBegin += new System.EventHandler(this.BResize);
            this.ResizeEnd += new System.EventHandler(this.EResize);
            this.EditorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.Button CanceleBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}