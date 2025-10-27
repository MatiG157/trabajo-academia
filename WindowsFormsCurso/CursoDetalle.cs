using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Cursos;
using API.Comisiones;
using API.Materias;
using API.Usuarios;
using API.Personas;
using API.DocentesCursos;

namespace WindowsForms
{

    public enum FormMode
    {
        Add,
        Update
    }

    public partial class CursoDetalle : Form
    {
        private CursoDTO curso;
        private FormMode mode;

        public CursoDTO Curso
        {
            get { return curso; }
            set
            {
                curso = value;
                this.SetCurso();
            }
        }



        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }

        public CursoDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;

        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Curso.IdMateria = (int)materiaDropDown.SelectedValue;
                this.Curso.IdComision = (int)comisionesDropDown.SelectedValue;
                this.Curso.Descripcion = textBoxDescripcion.Text;
                this.Curso.AnioCalendario = (int)AnioCalendarioNumericUpDown.Value;
                this.Curso.Cupo = (int)cupoNumericUpDown.Value;


                if (this.Mode == FormMode.Update)
                {
                    await CursoApiClient.UpdateAsync(this.Curso);

                    var docenteCurso = new DocenteCursoDTO();
                    docenteCurso.IdCurso = cursoCreado.IdCurso;
                    docenteCurso.IdDocente = (int)this.profesorDropDown.SelectedValue;
                    docenteCurso.Cargo = (string)this.cargosDropDown.SelectedItem;
                    await DocenteCursoApiClient.UpdateAsync(docenteCurso);


                }
                else
                {
                    var cursoCreado = await CursoApiClient.AddAsync(this.Curso);

                    var docenteCurso = new DocenteCursoDTO();
                    docenteCurso.IdCurso = cursoCreado.IdCurso;
                    docenteCurso.IdDocente = (int)this.profesorDropDown.SelectedValue;
                    docenteCurso.Cargo = (string)this.cargosDropDown.SelectedItem;
                    await DocenteCursoApiClient.AddAsync(docenteCurso);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCurso()
        {

            this.AnioCalendarioNumericUpDown.Maximum = 99999;
            this.cupoNumericUpDown.Maximum = 999999;




            this.materiaDropDown.SelectedValue = this.Curso.IdMateria;
            this.comisionesDropDown.SelectedValue = this.Curso.IdComision;
            this.textBoxDescripcion.Text = this.Curso.Descripcion;
            this.AnioCalendarioNumericUpDown.Value = this.Curso.AnioCalendario;
            this.cupoNumericUpDown.Value = this.Curso.Cupo;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
        }

        private async void CursoDetalle_Load(object sender, EventArgs e)
        {
            var comisiones = await ComisionApiClient.GetAllAsync();
            comisionesDropDown.DataSource = comisiones;
            comisionesDropDown.DisplayMember = "Display"; // Muestra la descripción
            comisionesDropDown.ValueMember = "IdComision";

            this.cargosDropDown.Items.Add("Teoría");
            this.cargosDropDown.Items.Add("Práctica");
            this.cargosDropDown.SelectedItem = "Teoría";

            var materias = await MateriaApiClient.GetAllAsync();
            materiaDropDown.DataSource = materias;
            materiaDropDown.DisplayMember = "Descripcion";
            materiaDropDown.ValueMember = "IdMateria";

            var personas = await PersonaApiClient.GetAllAsync();
            var usuarios = await UsuarioApiClient.GetAllAsync();




            var profesores = (from persona in personas
                              join usuario in usuarios on persona.IdPersona equals usuario.IdPersona
                              where persona.TipoPersona == "Docente"
                              select new
                              {
                                  IdPersona = persona.IdPersona,
                                  NombreCompleto = $"{usuario.NombreUsuario} {usuario.Apellido}",
                              }).ToList();


            profesorDropDown.DataSource = profesores;
            profesorDropDown.DisplayMember = "NombreCompleto";
            profesorDropDown.ValueMember = "IdPersona";
        }
    }
}
