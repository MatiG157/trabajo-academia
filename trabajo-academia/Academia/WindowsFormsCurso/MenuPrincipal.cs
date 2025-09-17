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
    }
}

