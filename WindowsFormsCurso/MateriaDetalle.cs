using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Comisiones;
using API.Materias;
using API.Planes;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class MateriaDetalle : Form
    {
        private MateriaDTO materia;
        private FormMode mode;

        public MateriaDTO Materia
        {
            get { return materia; }
            set
            {
                materia = value;
                this.SetMateria();
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

        public MateriaDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {

                this.Materia.Descripcion = (string)DescripcionRichTextBox.Text;
                this.Materia.HsSemanales = (int)horasSemanalesNumericUpDown.Value;
                this.Materia.HsTotales = (int)horasTotalesNumericUpDown.Value;
                this.Materia.IdPlan = (int)planDropDown.SelectedValue;



                if (this.Mode == FormMode.Update)
                {
                    await MateriaApiClient.UpdateAsync(this.Materia);
                }
                else
                {
                    await MateriaApiClient.AddAsync(this.Materia);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetMateria()
        {

            this.horasSemanalesNumericUpDown.Maximum = 999999;
            this.horasTotalesNumericUpDown.Maximum = 999999;

            this.DescripcionRichTextBox.Text = this.Materia.Descripcion;
            this.horasSemanalesNumericUpDown.Value = this.Materia.HsSemanales;
            this.horasTotalesNumericUpDown.Value = this.Materia.HsTotales;
            this.planDropDown.SelectedValue = this.Materia.IdPlan;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Materia_Load(object sender, EventArgs e)
        {

            var planes = await PlanApiClient.GetAllAsync();
            planDropDown.DataSource = planes;
            planDropDown.DisplayMember = "Descripcion"; 
            planDropDown.ValueMember = "IdPlan";

        }
    }
}

