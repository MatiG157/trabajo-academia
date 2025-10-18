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

namespace WindowsFormsCurso
{
    public partial class AlumnosLista : Form
    {
        public AlumnosLista()
        {
            InitializeComponent();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            try
            {

                var personas = await PersonaApiClient.GetAllAsync();
                var alumnos = personas.Where(p => p.TipoPersona == "alumno").ToList();


                this.comisionesDataGridView.DataSource = null;
                this.comisionesDataGridView.DataSource = alumnos;

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
    }
}
