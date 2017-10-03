namespace DolinskSportSchool
{
    partial class DeveloperInfo
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
            this.DeveloperRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // DeveloperRTB
            // 
            this.DeveloperRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeveloperRTB.Location = new System.Drawing.Point(12, 12);
            this.DeveloperRTB.Name = "DeveloperRTB";
            this.DeveloperRTB.ReadOnly = true;
            this.DeveloperRTB.Size = new System.Drawing.Size(314, 223);
            this.DeveloperRTB.TabIndex = 0;
            this.DeveloperRTB.Text = "Разработчик: Дмитрий \"Keltar Helviett\" Терехов \nКонтактная информация:\n  - E-mail" +
    ": keltarhelviett@gmail.com";
            // 
            // DeveloperInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 264);
            this.Controls.Add(this.DeveloperRTB);
            this.Name = "DeveloperInfo";
            this.Text = "DeveloperInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox DeveloperRTB;
    }
}