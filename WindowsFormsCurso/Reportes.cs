using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace WindowsFormsCurso
{
    public partial class Reportes : Form
    {/*
        public Reportes()
        {
            InitializeComponent();
        }

        // Método para obtener los datos
        private DataTable ObtenerCursos()
        {
            var dt = new DataTable();
            string connectionString = "TU_CONEXION_SQL";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT Id, Nombre, Descripcion FROM Cursos", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                conn.Open();
                da.Fill(dt);
            }
            return dt;
        }

        private void reporteCursosButton_Click(object sender, EventArgs e)
        {
            // Aquí puedes llamar a ObtenerCursos()
        }
    */}
}
