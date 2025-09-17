using DTOs;
using API.Usuarios;
using WindowsForms;

namespace WindowsForms
{
    public partial class UsuariosLista : Form
    {
        public UsuariosLista()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            UsuarioDetalle usuarioDetalle = new UsuarioDetalle();

            UsuarioDTO usuarioNuevo = new UsuarioDTO();

            usuarioDetalle.Mode2 = FormMode2.Add;
            usuarioDetalle.Usuario = usuarioNuevo;

            usuarioDetalle.ShowDialog();

            this.GetAllAndLoad();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDetalle usuarioDetalle = new UsuarioDetalle();

                int id = this.SelectedItem().IdUsuario;

                UsuarioDTO usuario = await UsuarioApiClient.GetAsync(id);

                usuarioDetalle.Mode2 = FormMode2.Update;
                usuarioDetalle.Usuario = usuario;
                usuarioDetalle.ShowDialog();

                this.GetAllAndLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuario para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.SelectedItem().IdUsuario;

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el usuario con Id {id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await UsuarioApiClient.DeleteAsync(id);
                    this.GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                this.usuariosDataGridView.DataSource = null;
                this.usuariosDataGridView.DataSource = await UsuarioApiClient.GetAllAsync();

                if (this.usuariosDataGridView.Rows.Count > 0)
                {
                    this.usuariosDataGridView.Rows[0].Selected = true;
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
                MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.eliminarButton.Enabled = false;
                this.modificarButton.Enabled = false;
            }
        }

        private UsuarioDTO SelectedItem()
        {
            UsuarioDTO usuario;

            usuario = (UsuarioDTO)usuariosDataGridView.SelectedRows[0].DataBoundItem;

            return usuario;
        }

        private void usuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
