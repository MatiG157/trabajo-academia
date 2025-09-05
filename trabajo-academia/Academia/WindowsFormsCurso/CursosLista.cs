using DTOs;
using API.Cursos;

namespace WindowsForms
{
    public partial class CursosLista : Form
    {
        public CursosLista()
        {
            InitializeComponent();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            CursoDetalle cursoDetalle = new CursoDetalle();

            CursoDTO cursoNuevo = new CursoDTO();

            cursoDetalle.Mode = FormMode.Add;
            cursoDetalle.Curso = cursoNuevo;

            cursoDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CursoDetalle cursoDetalle = new CursoDetalle();

                int id = this.SelectedItem().IdCurso;

                CursoDTO curso = await CursoApiClient.GetAsync(id);

                cursoDetalle.Mode = FormMode.Update;
                cursoDetalle.Curso = curso;

                cursoDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar curso para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().IdCurso;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el curso con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await CursoApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.cursosDataGridView.DataSource = null;
                this.cursosDataGridView.DataSource = await CursoApiClient.GetAllAsync();

                if (this.cursosDataGridView.Rows.Count > 0)
                {
                    this.cursosDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private CursoDTO SelectedItem()
        {
            CursoDTO curso;

            curso = (CursoDTO)cursosDataGridView.SelectedRows[0].DataBoundItem;

            return curso;
        }

        private void cursosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
