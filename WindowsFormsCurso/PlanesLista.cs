using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Planes;
using DTOs;
using WindowsForms;

namespace WindowsFormsCurso
{
    public partial class PlanesLista : Form
    {
        public PlanesLista()
        {
            InitializeComponent();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {

            PlanDetalle planDetalle = new PlanDetalle();

            PlanDTO planNuevo = new PlanDTO();

            planDetalle.Mode = FormMode.Add;
            planDetalle.Plan = planNuevo;

            planDetalle.ShowDialog();

            this.GetAllAndLoad();

        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {

            try
            {
                PlanDetalle planDetalle = new PlanDetalle();

                int id = this.SelectedItem().IdPlan;

                PlanDTO plan = await PlanApiClient.GetAsync(id);

                planDetalle.Mode = FormMode.Update;
                planDetalle.Plan = plan;

                planDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar plan para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {

            try
            {
                int id = this.SelectedItem().IdPlan;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el plan con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await PlanApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refrescarButton_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }


        private void planes_load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }



        private async void GetAllAndLoad()
        {
            try
            {
                this.planesDataGridView.DataSource = null;
                this.planesDataGridView.DataSource = await PlanApiClient.GetAllAsync();

                if (this.planesDataGridView.Rows.Count > 0)
                {
                    this.planesDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private PlanDTO SelectedItem()
        {
            PlanDTO plan;

            plan = (PlanDTO)planesDataGridView.SelectedRows[0].DataBoundItem;

            return plan;
        }

    }
}
