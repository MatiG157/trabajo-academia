using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Personas;
using API.Comisiones;
using DTOs;
using API.Personas;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class PersonasLista : Form
    {
        public PersonasLista()
        {
            InitializeComponent();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }


        private async void GetAllAndLoad()
        {
            try
            {

                var personas = await PersonaApiClient.GetAllAsync();


                this.personasDataGridView.DataSource = null;
                this.personasDataGridView.DataSource = personas;

                if (this.personasDataGridView.Rows.Count > 0)
                {
                    this.personasDataGridView.Rows[0].Selected = true;
                    this.eliminarButton.Enabled = true;
                    this.modificarButton.Enabled = true;
                }
                else
                {
                    this.eliminarButton.Enabled = false;
                    this.modificarButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaDetalle personaDetalle = new PersonaDetalle();

                int id = this.SelectedItem().IdPersona;

                PersonaDTO persona = await PersonaApiClient.GetAsync(id);

                personaDetalle.Mode = FormMode.Update;
                personaDetalle.Persona = persona;

                personaDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar persona para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().IdPersona;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la persona con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await PersonaApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescarButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private PersonaDTO SelectedItem()
        {
            PersonaDTO persona;

            persona = (PersonaDTO)personasDataGridView.SelectedRows[0].DataBoundItem;

            return persona;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            PersonaDetalle personaDetalle = new PersonaDetalle();

            PersonaDTO personaNueva = new PersonaDTO();

            personaDetalle.Mode = FormMode.Add;
            personaDetalle.Persona = personaNueva;

            personaDetalle.ShowDialog();

            this.GetAllAndLoad();
        }
    }
}
