using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursosLista form = new CursosLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            form.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosLista form = new UsuariosLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            form.Show();
        }

        private void comisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComisionesLista form = new ComisionesLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            form.Show();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasLista form = new MateriasLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            form.Show();
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesLista form = new PlanesLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            form.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadesLista form = new EspecialidadesLista();
            form.MdiParent = this;   // Se abre dentro del contenedor MDI
            form.Show();
        }
    }
}

