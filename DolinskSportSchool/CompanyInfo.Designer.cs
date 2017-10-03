namespace DolinskSportSchool
{
    partial class CompanyInfo
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
            this.Info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Info.Location = new System.Drawing.Point(12, 12);
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Size = new System.Drawing.Size(320, 153);
            this.Info.TabIndex = 5;
            this.Info.Text = "Контактная информация:\n\n- Телефон/факс: (42442) 2-76-61\n\n- Электронная почта: dol" +
    "insk-sport@mail.ru, cjss6503@mail.ru\n\n- Интернет сайт: www.cjss6503.ru";
            this.Info.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RB_LinkClick);
            // 
            // CompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.Info);
            this.MaximumSize = new System.Drawing.Size(350, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CompanyInfo";
            this.Text = "Об учреждении";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox Info;
    }
}