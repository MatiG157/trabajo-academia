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
using API.Usuarios;
using API.Materias;
using API.Personas;
using DTOs;
using WindowsForms;


namespace WindowsFormsCurso
{
    public partial class PonerNotas : Form
    {
        private UsuarioDTO usuario;
        private List<AlumnoNotaDTO> alumnosNota;

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
            this.GetAllAndLoad();
        }

        private async void buttonPonerNota_Click(object sender, EventArgs e)
        {
            NotaDetalle notaDetalle = new NotaDetalle();

            AlumnoNotaDTO alumno = SelectedItem();

            notaDetalle.Alumno = alumno;

            notaDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            try
            {
                var personas = await PersonaApiClient.GetAllAsync();
                var alumnoInscripcion = await AlumnoInscripcionApiClient.GetAllAsync();
                var usuarios = await UsuarioApiClient.GetAllAsync();

                var alumnos = (from persona in personas
                               join alumnoInscripcionItem in alumnoInscripcion on persona.IdPersona equals alumnoInscripcionItem.IdAlumno
                               join usuario in usuarios on persona.IdPersona equals usuario.IdPersona
                               where alumnoInscripcionItem.IdCurso == (int)this.comboBoxCursos.SelectedValue
                               select new AlumnoNotaDTO
                               {
                                   IdInscripcion = alumnoInscripcionItem.IdInscripcion,
                                   IdCurso = alumnoInscripcionItem.IdCurso,
                                   Legajo = persona.Legajo,
                                   NombreCompleto = $"{usuario.Apellido}",
                                   Nota = alumnoInscripcionItem.Nota,
                                   Condicion = alumnoInscripcionItem.Condicion

                               }).ToList();

                Console.WriteLine($"{alumnos}");

                this.dataGridViewAlumnos.DataSource = null;
                this.dataGridViewAlumnos.DataSource = alumnos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de alumnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private AlumnoNotaDTO SelectedItem()
        {
            AlumnoNotaDTO alumnoNota;

            alumnoNota = (AlumnoNotaDTO)dataGridViewAlumnos.SelectedRows[0].DataBoundItem;

            return alumnoNota;
        }
    }
}
