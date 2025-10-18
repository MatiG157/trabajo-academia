using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Especialidades;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class EspecialidadDetalle : Form
    {
        private EspecialidadDTO especialidad;
        private FormMode mode;

        public EspecialidadDTO Especialidad
        {
            get { return especialidad; }
            set
            {
                especialidad = value;
                this.SetEspecialidad();
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


        public EspecialidadDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }


        private async void aceptarButton_Click(object sender, EventArgs e)
        {

            try
            {

                this.Especialidad.Descripcion = (string)DescripcionRichTextBox.Text;



                if (this.Mode == FormMode.Update)
                {
                    await EspecialidadApiClient.UpdateAsync(this.Especialidad);
                }
                else
                {
                    await EspecialidadApiClient.AddAsync(this.Especialidad);
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

        private void SetEspecialidad()
        {
            this.DescripcionRichTextBox.Text = this.Especialidad.Descripcion;
        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
        }
    }
}
