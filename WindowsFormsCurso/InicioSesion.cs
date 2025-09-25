using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using API.Cursos;
using API.Usuarios;
using DTOs;

namespace WindowsFormsCurso
{
    public partial class InicioSesion : Form
    {
        private UsuarioDTO usuario;
        private UsuarioDTO usuarioBD;
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void registroLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void iniciarSesionButton_Click(object sender, EventArgs e)
        {
            usuario = new UsuarioDTO();

            this.usuario.Email = (string)usuarioTextBox.Text;
            this.usuario.Clave = (string)contraseñaTextBox.Text;


            // usuarioBD = await UsuarioApiClient.GetAsync(this.usuario.Email);

            if (this.usuario.Email == "admin@gmail.com" && this.usuario.Clave == "1234")
            {
                MenuPrincipal form = new MenuPrincipal();
                // Se abre dentro del contenedor MDI
                form.Show();

            }
            else
            {
                MessageBox.Show("Error");

            }

        }
    }
}
