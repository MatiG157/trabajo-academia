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
    public partial class NotaDetalle : Form
    {
        private PersonaDTO alumno;

        public PersonaDTO Alumno
        {
            get { return alumno; }
            set
            {
                alumno = value;
            }
        }
        public NotaDetalle()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void buttonAceptar_Click(object sender, EventArgs e)
        {
            await AlumnoInscripcionApiClient.PonerNotaAsync(alumno.IdPersona, (int)this.numericUpDownNota.Value);
        }
    }
}
