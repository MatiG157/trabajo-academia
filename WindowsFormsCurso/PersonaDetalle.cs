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
using API.Personas;
using API.Planes;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class PersonaDetalle : Form
    {

        private PersonaDTO persona;
        private FormMode mode;

        public PersonaDTO Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                this.SetPersona();
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

        public PersonaDetalle()
        {
            InitializeComponent();

            Mode = FormMode.Add;
        }



        private void SetPersona()
        {

            this.textBoxDireccion.Text = this.Persona.Direccion;
            this.legajoNumericUpDown.Value = this.Persona.Legajo;
            this.textBoxTelefono.Text = this.Persona.Telefono;
            if (this.Persona.FechaNacimiento < this.dateTimePickerFechaNacimiento.MinDate ||
                this.Persona.FechaNacimiento > this.dateTimePickerFechaNacimiento.MaxDate)
            {
                this.dateTimePickerFechaNacimiento.Value = this.dateTimePickerFechaNacimiento.MinDate;
            }
            else
            {
                this.dateTimePickerFechaNacimiento.Value = this.Persona.FechaNacimiento;
            }
            this.tipoPersonaDropDown.SelectedItem = this.Persona.TipoPersona;
            this.planDropDown.SelectedValue = this.Persona.IdPlan;

        }

        private void SetFormMode(FormMode value)
        {
            mode = value;
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {

                this.Persona.Direccion = (string)textBoxDireccion.Text;
                this.Persona.Legajo = (int)legajoNumericUpDown.Value;
                this.Persona.Telefono = (string)textBoxTelefono.Text;
                this.Persona.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                this.Persona.TipoPersona = tipoPersonaDropDown.SelectedItem.ToString();
                this.Persona.IdPlan = (int)planDropDown.SelectedValue;

                if (this.Mode == FormMode.Update)
                {
                    await PersonaApiClient.UpdateAsync(this.Persona);
                }
                else
                {
                    await PersonaApiClient.AddAsync(this.Persona);
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

        private async void Persona_Load(object sender, EventArgs e)
        {

            var planes = await PlanApiClient.GetAllAsync();
            this.planDropDown.DataSource = planes;
            this.planDropDown.DisplayMember = "Descripcion";
            this.planDropDown.ValueMember = "IdPlan";

            this.tipoPersonaDropDown.Items.Add("Docente");
            this.tipoPersonaDropDown.Items.Add("Alumno");
            this.tipoPersonaDropDown.SelectedItem = "Alumno";

        }
    }
}
