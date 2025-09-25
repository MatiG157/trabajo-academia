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
using API.Materia;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class MateriasLista : Form
    {
        public MateriasLista()
        {
            InitializeComponent();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().IdMateria;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la materia con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await MateriaApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaDetalle materiaDetalle = new MateriaDetalle();

                int id = this.SelectedItem().IdMateria;

                MateriaDTO materia = await MateriaApiClient.GetAsync(id);

                materiaDetalle.Mode = FormMode.Update;
                materiaDetalle.Materia = materia;

                materiaDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materia para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            MateriaDetalle materiaDetalle = new MateriaDetalle();

            MateriaDTO materiaNueva = new MateriaDTO();

            materiaDetalle.Mode = FormMode.Add;
            materiaDetalle.Materia = materiaNueva;

            materiaDetalle.ShowDialog();

            this.GetAllAndLoad();

        }

        private void materias_load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.materiasDataGridView.DataSource = null;
                this.materiasDataGridView.DataSource = await MateriaApiClient.GetAllAsync();

                if (this.materiasDataGridView.Rows.Count > 0)
                {
                    this.materiasDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private MateriaDTO SelectedItem()
        {
            MateriaDTO materia;

            materia = (MateriaDTO)materiasDataGridView.SelectedRows[0].DataBoundItem;

            return materia;
        }
    }
}
