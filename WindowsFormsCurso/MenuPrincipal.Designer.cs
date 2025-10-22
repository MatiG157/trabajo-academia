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
            planToolStripMenuItem = new ToolStripMenuItem();
            alumnosToolStripMenuItem = new ToolStripMenuItem();
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            funcionaliadprofesoresToolStripMenuItem = new ToolStripMenuItem();
            ponerNotasToolStripMenuItem = new ToolStripMenuItem();
            funcionalidadAlumnosToolStripMenuItem = new ToolStripMenuItem();
            inscribirseACursoToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { listasToolStripMenuItem, funcionaliadprofesoresToolStripMenuItem, funcionalidadAlumnosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // listasToolStripMenuItem
            // 
            listasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cursoToolStripMenuItem, usuarioToolStripMenuItem, comisionToolStripMenuItem, materiaToolStripMenuItem, planToolStripMenuItem, alumnosToolStripMenuItem, especialidadesToolStripMenuItem });
            listasToolStripMenuItem.Name = "listasToolStripMenuItem";
            listasToolStripMenuItem.Size = new Size(48, 20);
            listasToolStripMenuItem.Text = "&Listas";
            // 
            // cursoToolStripMenuItem
            // 
            cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            cursoToolStripMenuItem.Size = new Size(150, 22);
            cursoToolStripMenuItem.Text = "&Cursos";
            cursoToolStripMenuItem.Click += cursoToolStripMenuItem_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(150, 22);
            usuarioToolStripMenuItem.Text = "&Usuarios";
            usuarioToolStripMenuItem.Click += usuarioToolStripMenuItem_Click;
            // 
            // comisionToolStripMenuItem
            // 
            comisionToolStripMenuItem.Name = "comisionToolStripMenuItem";
            comisionToolStripMenuItem.Size = new Size(150, 22);
            comisionToolStripMenuItem.Text = "C&omisiones";
            comisionToolStripMenuItem.Click += comisionToolStripMenuItem_Click;
            // 
            // materiaToolStripMenuItem
            // 
            materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            materiaToolStripMenuItem.Size = new Size(150, 22);
            materiaToolStripMenuItem.Text = "&Materias";
            materiaToolStripMenuItem.Click += materiaToolStripMenuItem_Click;
            // 
            // planToolStripMenuItem
            // 
            planToolStripMenuItem.Name = "planToolStripMenuItem";
            planToolStripMenuItem.Size = new Size(150, 22);
            planToolStripMenuItem.Text = "&Planes";
            planToolStripMenuItem.Click += planToolStripMenuItem_Click;
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new Size(150, 22);
            alumnosToolStripMenuItem.Text = "&Alumnos";
            // 
            // especialidadesToolStripMenuItem
            // 
            especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            especialidadesToolStripMenuItem.Size = new Size(150, 22);
            especialidadesToolStripMenuItem.Text = "&Especialidades";
            especialidadesToolStripMenuItem.Click += especialidadesToolStripMenuItem_Click;
            // 
            // funcionaliadprofesoresToolStripMenuItem
            // 
            funcionaliadprofesoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ponerNotasToolStripMenuItem });
            funcionaliadprofesoresToolStripMenuItem.Name = "funcionaliadprofesoresToolStripMenuItem";
            funcionaliadprofesoresToolStripMenuItem.Size = new Size(145, 20);
            funcionaliadprofesoresToolStripMenuItem.Text = "&Funcionaliad profesores";
            // 
            // ponerNotasToolStripMenuItem
            // 
            ponerNotasToolStripMenuItem.Name = "ponerNotasToolStripMenuItem";
            ponerNotasToolStripMenuItem.Size = new Size(137, 22);
            ponerNotasToolStripMenuItem.Text = "&Poner notas";
            // 
            // funcionalidadAlumnosToolStripMenuItem
            // 
            funcionalidadAlumnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inscribirseACursoToolStripMenuItem });
            funcionalidadAlumnosToolStripMenuItem.Name = "funcionalidadAlumnosToolStripMenuItem";
            funcionalidadAlumnosToolStripMenuItem.Size = new Size(143, 20);
            funcionalidadAlumnosToolStripMenuItem.Text = "F&uncionalidad alumnos";
            // 
            // inscribirseACursoToolStripMenuItem
            // 
            inscribirseACursoToolStripMenuItem.Name = "inscribirseACursoToolStripMenuItem";
            inscribirseACursoToolStripMenuItem.Size = new Size(168, 22);
            inscribirseACursoToolStripMenuItem.Text = "&Inscribirse a curso";
            inscribirseACursoToolStripMenuItem.Click += inscribirseACursoToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Silver;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(66, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(664, 343);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(267, 107);
            label1.Name = "label1";
            label1.Size = new Size(302, 65);
            label1.TabIndex = 4;
            label1.Text = "BIENVENIDO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipal";
            Text = "Academia";
            Load += Menu_load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private ToolStripMenuItem planToolStripMenuItem;
        private ToolStripMenuItem alumnosToolStripMenuItem;
        private ToolStripMenuItem funcionaliadprofesoresToolStripMenuItem;
        private ToolStripMenuItem ponerNotasToolStripMenuItem;
        private ToolStripMenuItem especialidadesToolStripMenuItem;
        private ToolStripMenuItem funcionalidadAlumnosToolStripMenuItem;
        private ToolStripMenuItem inscribirseACursoToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label1;
    }
}