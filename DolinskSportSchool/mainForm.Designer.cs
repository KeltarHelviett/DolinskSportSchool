namespace DolinskSportSchool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MTables = new System.Windows.Forms.ToolStripMenuItem();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MAboutDeveloper = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.оРазработчикеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MTables,
            this.базаДанныхToolStripMenuItem,
            this.MAbout});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(334, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            this.Menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ItemClicked);
            // 
            // MTables
            // 
            this.MTables.Name = "MTables";
            this.MTables.Size = new System.Drawing.Size(69, 20);
            this.MTables.Text = "Таблицы";
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // MAbout
            // 
            this.MAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAboutDeveloper,
            this.оРазработчикеToolStripMenuItem});
            this.MAbout.Name = "MAbout";
            this.MAbout.Size = new System.Drawing.Size(65, 20);
            this.MAbout.Text = "Справка";
            // 
            // MAboutDeveloper
            // 
            this.MAboutDeveloper.Name = "MAboutDeveloper";
            this.MAboutDeveloper.Size = new System.Drawing.Size(162, 22);
            this.MAboutDeveloper.Text = "Об учреждении";
            this.MAboutDeveloper.Click += new System.EventHandler(this.developerToolStripMenuItem_Click);
            // 
            // SaveDialog
            // 
            this.SaveDialog.Filter = "SQLite Data Base|*.db";
            // 
            // OpenDialog
            // 
            this.OpenDialog.Filter = "SQLite Data Base|*.db";
            // 
            // оРазработчикеToolStripMenuItem
            // 
            this.оРазработчикеToolStripMenuItem.Name = "оРазработчикеToolStripMenuItem";
            this.оРазработчикеToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.оРазработчикеToolStripMenuItem.Text = "О разработчике";
            this.оРазработчикеToolStripMenuItem.Click += new System.EventHandler(this.оРазработчикеToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 308);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ДЮСШ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MTables;
        private System.Windows.Forms.ToolStripMenuItem MAbout;
        private System.Windows.Forms.ToolStripMenuItem MAboutDeveloper;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оРазработчикеToolStripMenuItem;
    }
}

