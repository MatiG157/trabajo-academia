using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace API.Clients
{
    public class DocenteCursoApiClient
    {
        private static HttpClient client = new HttpClient();
        static DocenteCursoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5077/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<DocenteCursoDTO?>> GetDocenteCursoByCriteria(int idDocente)
        {

            var criteria = new DocenteCursoCriteriaDTO { IdDocente = idDocente };

            var response = await client.GetAsync($"docentesCursos/criteria/{criteria.IdDocente}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO?>>();

            return null;
        }
    }
}
