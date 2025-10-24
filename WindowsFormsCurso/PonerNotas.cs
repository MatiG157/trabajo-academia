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
using API.Cursos;
using API.DocentesCursos;
using API.Materias;
using API.Personas;
using DTOs;
using WindowsForms;


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

        private async void buttonFiltrar_Click(object sender, EventArgs e)
        {
            var personas = await PersonaApiClient.GetAllAsync();
            var alumnoInscripcion = await AlumnoInscripcionApiClient.GetAllAsync();

            var alumnos = (from persona in personas
                           join alumnoInscripcionItem in alumnoInscripcion on persona.IdPersona equals alumnoInscripcionItem.IdAlumno
                           where alumnoInscripcionItem.IdCurso == (int)this.comboBoxCursos.SelectedValue
                           select new
                           {
                               IdPersona = persona.IdPersona,
                               NombreCompleto = $"{usuario.NombreUsuario} {usuario.Apellido}",
                               Nota = alumnoInscripcionItem.Nota

                           }).ToList();

            dataGridViewAlumnos.DataSource = null;
            dataGridViewAlumnos.DataSource = alumnos;
        }

        private void buttonPonerNota_Click(object sender, EventArgs e)
        {
            NotaDetalle notaDetalle = new NotaDetalle();

            var alumno = SelectedItem();

            notaDetalle.Alumno = alumno;

            notaDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.dataGridViewAlumnos.DataSource = null;
                this.dataGridViewAlumnos.DataSource = await MateriaApiClient.GetAllAsync();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de alumnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private dynamic SelectedItem()
        {
            if (dataGridViewAlumnos.SelectedRows.Count > 0)
            {
                return dataGridViewAlumnos.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

    }
}
