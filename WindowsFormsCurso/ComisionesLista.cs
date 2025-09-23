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
using API.Cursos;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class ComisionesLista : Form
    {
        public ComisionesLista()
        {
            InitializeComponent();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.comisionesDataGridView.DataSource = null;
                this.comisionesDataGridView.DataSource = await ComisionApiClient.GetAllAsync();

                if (this.comisionesDataGridView.Rows.Count > 0)
                {
                    this.comisionesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private ComisionDTO SelectedItem()
        {
            ComisionDTO comision;

            comision = (ComisionDTO)comisionesDataGridView.SelectedRows[0].DataBoundItem;

            return comision;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            ComisionDetalle comisionDetalle = new ComisionDetalle();

            ComisionDTO comisionNueva = new ComisionDTO();

            comisionDetalle.Mode = FormMode.Add;
            comisionDetalle.Comision = comisionNueva;

            comisionDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionDetalle comisionDetalle = new ComisionDetalle();

                int id = this.SelectedItem().IdComision;

                ComisionDTO comision = await ComisionApiClient.GetAsync(id);

                comisionDetalle.Mode = FormMode.Update;
                comisionDetalle.Comision = comision;

                comisionDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar comisiones para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().IdComision;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la comision con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ComisionApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar comision: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
