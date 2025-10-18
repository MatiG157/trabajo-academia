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
using API.Especialidades;
using API.Materias;
using API.Planes;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class PlanDetalle : Form
    {
        private PlanDTO plan;
        private FormMode mode;

        public PlanDTO Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                this.SetPlan();
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

        public PlanDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }


        private void SetPlan()
        {


            this.DescripcionRichTextBox.Text = this.Plan.Descripcion;
            this.especialidadDropDown.SelectedValue = this.Plan.IdEspecialidad;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
        }

        private async void Plan_Load(object sender, EventArgs e)
        {

            var especialidades = await EspecialidadApiClient.GetAllAsync();
            especialidadDropDown.DataSource = especialidades;
            especialidadDropDown.DisplayMember = "Descripcion";
            especialidadDropDown.ValueMember = "IdEspecialidad";

        }

        private async void aceptarButton_Click_1(object sender, EventArgs e)
        {
            try
            {

                this.Plan.Descripcion = (string)DescripcionRichTextBox.Text;
                this.Plan.IdEspecialidad = (int)especialidadDropDown.SelectedValue;



                if (this.Mode == FormMode.Update)
                {
                    await PlanApiClient.UpdateAsync(this.Plan);
                }
                else
                {
                    await PlanApiClient.AddAsync(this.Plan);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelarButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
