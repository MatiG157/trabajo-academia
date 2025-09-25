namespace WindowsFormsCurso
{
    partial class MenuPrincipal
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
            menuStrip1 = new MenuStrip();
            listasToolStripMenuItem = new ToolStripMenuItem();
            cursoToolStripMenuItem = new ToolStripMenuItem();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            comisionToolStripMenuItem = new ToolStripMenuItem();
            materiaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { listasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // listasToolStripMenuItem
            // 
            listasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cursoToolStripMenuItem, usuarioToolStripMenuItem, comisionToolStripMenuItem, materiaToolStripMenuItem });
            listasToolStripMenuItem.Name = "listasToolStripMenuItem";
            listasToolStripMenuItem.Size = new Size(48, 20);
            listasToolStripMenuItem.Text = "&Listas";
            // 
            // cursoToolStripMenuItem
            // 
            cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            cursoToolStripMenuItem.Size = new Size(180, 22);
            cursoToolStripMenuItem.Text = "&Curso";
            cursoToolStripMenuItem.Click += cursoToolStripMenuItem_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(180, 22);
            usuarioToolStripMenuItem.Text = "&Usuario";
            usuarioToolStripMenuItem.Click += usuarioToolStripMenuItem_Click;
            // 
            // comisionToolStripMenuItem
            // 
            comisionToolStripMenuItem.Name = "comisionToolStripMenuItem";
            comisionToolStripMenuItem.Size = new Size(180, 22);
            comisionToolStripMenuItem.Text = "C&omision";
            comisionToolStripMenuItem.Click += comisionToolStripMenuItem_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(180, 22);
            materiaToolStripMenuItem.Text = "&Materia";
            materiaToolStripMenuItem.Click += materiaToolStripMenuItem_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipal";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem listasToolStripMenuItem;
        private ToolStripMenuItem cursoToolStripMenuItem;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem comisionToolStripMenuItem;
        private ToolStripMenuItem materiaToolStripMenuItem;
    }
}