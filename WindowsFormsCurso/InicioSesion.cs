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
using API.Personas;
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
            Registrarse form = new Registrarse();
            form.Show();
            this.Hide();

        }

        private async void iniciarSesionButton_Click(object sender, EventArgs e)
        {
            

            string email = usuarioTextBox.Text;
            string clave = contraseñaTextBox.Text;

            usuarioBD = await UsuarioApiClient.Login(email, clave);

            if (usuarioBD != null)
            {
                var persona = new PersonaDTO();

                persona = await PersonaApiClient.GetAsync(usuarioBD.IdPersona);

                MenuPrincipal form = new MenuPrincipal();
                form.Usuario = usuarioBD;
                form.Modo = persona.TipoPersona;
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

        }
    }
}
