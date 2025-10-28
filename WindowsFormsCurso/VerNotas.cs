using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.AlumnosInscripciones;
using DTOs;

namespace WindowsFormsCurso
{
    public partial class VerNotas : Form
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

        public VerNotas()
        {
            InitializeComponent();
        }

        private async void Load_Notas(object sender, EventArgs e)
        {
            var notas = await AlumnoInscripcionApiClient.GetAllAsync();

            var notasAlumno = notas.Where(n => n.IdAlumno == usuario.IdPersona).ToList();


            this.dataGridViewNotas.DataSource = null;
            this.dataGridViewNotas.DataSource = notasAlumno;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
