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
        private AlumnoNotaDTO alumno;

        public AlumnoNotaDTO Alumno
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
            await AlumnoInscripcionApiClient.PonerNotaAsync(alumno.IdInscripcion, alumno.IdCurso, (int)this.numericUpDownNota.Value);
            this.Close();
        }
    }
}
