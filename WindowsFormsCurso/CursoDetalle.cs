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
            //if (this.ValidateCurso())

            try
            {

                this.Curso.IdMateria = (int)idMateriaNumericUpDown.Value;
                this.Curso.IdComision = (int)idComisionNumericUpDown.Value;
                this.Curso.AnioCalendario = (int)AnioCalendarioNumericUpDown.Value;
                this.Curso.Cupo = (int)cupoNumericUpDown.Value;



                if (this.Mode == FormMode.Update)
                {
                    await CursoApiClient.UpdateAsync(this.Curso);
                }
                else
                {
                    await CursoApiClient.AddAsync(this.Curso);
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

            this.idMateriaNumericUpDown.Maximum = 99999;
            this.idComisionNumericUpDown.Maximum = 99999;
            this.AnioCalendarioNumericUpDown.Maximum = 99999;
            this.cupoNumericUpDown.Maximum = 999999;




            this.idMateriaNumericUpDown.Value = this.Curso.IdMateria;
            this.idComisionNumericUpDown.Value = this.Curso.IdComision;
            this.AnioCalendarioNumericUpDown.Value = this.Curso.AnioCalendario;
            this.cupoNumericUpDown.Value = this.Curso.Cupo;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;


        }


        private void AnioCalendarioNumericUpDown_TextChanged(object sender, EventArgs e)
        {

        }

        private void cupoNumericUpDown_TextChanged(object sender, EventArgs e)
        {

        }

        private void CursoDetalle_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cupoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cupoLabel_Click(object sender, EventArgs e)
        {

        }

        private void AnioCalendarioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
