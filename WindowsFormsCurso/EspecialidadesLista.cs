using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Cursos;
using API.Especialidades;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class EspecialidadesLista : Form
    {
        public EspecialidadesLista()
        {
            InitializeComponent();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            EspecialidadDetalle especialidadDetalle = new EspecialidadDetalle();

            EspecialidadDTO especialidadNueva = new EspecialidadDTO();

            especialidadDetalle.Mode = FormMode.Add;
            especialidadDetalle.Especialidad = especialidadNueva;

            especialidadDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDetalle especialidadDetalle = new EspecialidadDetalle();

                int id = this.SelectedItem().IdEspecialidad;

                EspecialidadDTO especialidad = await EspecialidadApiClient.GetAsync(id);

                especialidadDetalle.Mode = FormMode.Update;
                especialidadDetalle.Especialidad = especialidad;

                especialidadDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar especialidad para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().IdEspecialidad;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la especialidad con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await EspecialidadApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescarButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.especialidadesDataGridView.DataSource = null;
                this.especialidadesDataGridView.DataSource = await EspecialidadApiClient.GetAllAsync();

                if (this.especialidadesDataGridView.Rows.Count > 0)
                {
                    this.especialidadesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private EspecialidadDTO SelectedItem()
        {
            EspecialidadDTO especialidad;

            especialidad = (EspecialidadDTO)especialidadesDataGridView.SelectedRows[0].DataBoundItem;

            return especialidad;
        }
    }
}
