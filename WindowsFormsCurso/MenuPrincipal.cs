using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class MenuPrincipal : Form
    {
        private UsuarioDTO usuario;

        public UsuarioDTO Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
            }
        }

        private string modo;

        public string Modo
        {
            get { return modo; }
            set
            {
                modo = value;
            }
        }

        public MenuPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursosLista form = new CursosLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosLista form = new UsuariosLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void comisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComisionesLista form = new ComisionesLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasLista form = new MateriasLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesLista form = new PlanesLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadesLista form = new EspecialidadesLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void inscribirseACursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InscribirseACurso form = new InscribirseACurso();
            form.Usuario = this.usuario;
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            this.label1.SendToBack();
            this.pictureBox1.SendToBack();
            form.Show();
        }

        private void Menu_load(object sender, EventArgs e)
        {
            if (this.modo == "Alumno")
            {
                this.funcionaliadprofesoresToolStripMenuItem.Visible = false;
                this.listasToolStripMenuItem.Visible = false;
            }
            else if (this.modo == "Profesor")
            {
                this.funcionalidadAlumnosToolStripMenuItem.Visible = false;
                this.listasToolStripMenuItem.Visible = false;
            }
            else
            {
                //this.funcionalidadAlumnosToolStripMenuItem.Visible = false;
                //this.funcionaliadprofesoresToolStripMenuItem.Visible = false;
            }
        }
    }
}

