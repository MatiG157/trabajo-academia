using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using API.Cursos;
using DTOs;

namespace WindowsFormsCurso
{
    public partial class PonerNotas : Form
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


        public PonerNotas()
        {
            InitializeComponent();
        }

        private async void Poner_notas_load(object sender, EventArgs e)
        {
            var docenteCursos = await DocenteCursoApiClient.GetDocenteCursoByCriteria(usuario.IdPersona);

            var cursosProfesor = new List<CursoDTO>();

            if (docenteCursos != null)
            {
                foreach (var dc in docenteCursos)
                {
                    var curso = await CursoApiClient.GetAsync(dc.IdCurso);
                    if (curso != null)
                        cursosProfesor.Add(curso);
                }
            }
            else
            {
                MessageBox.Show("No tiene cursos asignados.");
                this.Close();
                return;
            }

                comboBoxCursos.DataSource = cursosProfesor;
            comboBoxCursos.DisplayMember = "Descripcion"; 
            comboBoxCursos.ValueMember = "IdCurso";
        }
    }
}
