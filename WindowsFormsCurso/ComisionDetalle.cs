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
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class ComisionDetalle : Form
    {
        private ComisionDTO comision;
        private FormMode mode;

        public ComisionDTO Comision
        {
            get { return comision; }
            set
            {
                comision = value;
                this.SetComision();
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


        public ComisionDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {

            try
            {

                this.Comision.Descripcion = (string)DescripcionRichTextBox.Text;
                this.Comision.AnioEspecialidad = (int)añoEspecialidadNumericUpDown.Value;
                this.Comision.IdPlan = (int)idPlanUpDown.Value;



                if (this.Mode == FormMode.Update)
                {
                    await ComisionApiClient.UpdateAsync(this.Comision);
                }
                else
                {
                    await ComisionApiClient.AddAsync(this.Comision);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetComision()
        {

            this.idPlanUpDown.Maximum = 999999;

            this.DescripcionRichTextBox.Text = this.Comision.Descripcion;
            this.añoEspecialidadNumericUpDown.Value = this.Comision.AnioEspecialidad;
            this.idPlanUpDown.Value = this.Comision.IdPlan;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
