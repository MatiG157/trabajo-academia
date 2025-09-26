using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCurso
{
    public partial class Registrarse : Form
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void iniciarSesionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InicioSesion form = new InicioSesion();
            form.Show();
            this.Close();
        }
    }
}
