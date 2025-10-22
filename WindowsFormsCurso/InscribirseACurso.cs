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
using API.Comisiones;
using API.Cursos;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class InscribirseACurso : Form
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

        public InscribirseACurso()
        {
            InitializeComponent();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }


        private async void GetAllAndLoad()
        {
            try
            {
                this.dataGridViewCursos.DataSource = null;
                this.dataGridViewCursos.DataSource = await CursoApiClient.GetAllAsync();

                if (this.dataGridViewCursos.Rows.Count > 0)
                {
                    this.dataGridViewCursos.Rows[0].Selected = true;
                    this.buttonInscribirse.Enabled = true;
                }
                else
                {
                    this.buttonInscribirse.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonInscribirse.Enabled = false;
            }
        }

        private async void buttonInscribirse_Click(object sender, EventArgs e)
        {
            try
            {

                var curso = this.SelectedItem();

                int cupo = (int)this.SelectedItem().Cupo;
                if ( cupo > 0) { 
                    AlumnoInscripcionDTO inscripcion = new AlumnoInscripcionDTO
                    {
                        Condicion = "Cursando",
                        Nota = null
                    };

                    inscripcion.IdAlumno = usuario.IdUsuario;
                    inscripcion.IdCurso = (int)this.SelectedItem().IdCurso;


                    await AlumnoInscripcionApiClient.AddAsync(inscripcion);

                    await CursoApiClient.BajarCupoAsync(curso);

                    MessageBox.Show("Inscripción realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No hay cupos para el curso seleccionado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CursoDTO SelectedItem()
        {
            CursoDTO curso;

            curso = (CursoDTO)dataGridViewCursos.SelectedRows[0].DataBoundItem;

            return curso;
        }
    }
}
