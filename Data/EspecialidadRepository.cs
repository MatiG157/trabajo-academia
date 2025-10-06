using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


namespace Data
{
    public class EspecialidadRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Especialidad especialidad)
        {
            using var context = CreateContext();
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var especialidad = context.Especialidades.Find(id);
            if (especialidad != null)
            {
                context.Especialidades.Remove(especialidad);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Especialidad? Get(int id)
        {
            using var context = CreateContext();
            return context.Especialidades
                .FirstOrDefault(e => e.IdEspecialidad == id);
        }

        public IEnumerable<Especialidad> GetAll()
        {
            using var context = CreateContext();
            return context.Especialidades
                .ToList();
        }

        public bool Update(Especialidad especialidad)
        {
            using var context = CreateContext();
            var existingEspecialidad = context.Especialidades.Find(especialidad.IdEspecialidad);
            if (existingEspecialidad != null)
            {

                existingEspecialidad.Descripcion = especialidad.Descripcion;

                context.SaveChanges();
                return true;
            }
            return false;
        }

     
        public IEnumerable<Especialidad> GetByCriteria(EspecialidadCriteria criteria)
        {
            const string sql = @"
                SELECT e.IdEspecialidad, e.Descripcion
                FROM Especialidades e             
                WHERE e.Descripcion LIKE @SearchTerm";


            var especialidades = new List<Especialidad>();
            string connectionString = new TPIContext().Database.GetConnectionString();
            string searchPattern = $"%{criteria.Texto}%";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SearchTerm", searchPattern);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var especialidad = new Especialidad(
                    reader.GetInt32(0),    // IdEspecialidad
                    reader.GetString(1)   // Descripcion
                   
                );


           
            }

            return especialidades;
        }

    }
}