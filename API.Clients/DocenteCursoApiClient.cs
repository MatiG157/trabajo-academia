using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace API.DocentesCursos
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

            var response = await client.GetAsync($"docentesCursos/criteria?idDocente={criteria.IdDocente}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<DocenteCursoDTO?>>();

            return null;
        }
    

        public async static Task AddAsync(DocenteCursoDTO docenteCursoDTO)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("docentesCursos", docenteCursoDTO);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear docenteCurso. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear docenteCurso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear docenteCurso: {ex.Message}", ex);
            }
        }
        /*
        public static async Task UpdateAsync(DocenteCursoDTO docenteCurso)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"docentesCursos/{docenteCurso.IdAsignacion}", docenteCurso);


                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar asignacion con Id {docenteCurso.IdAsignacion}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar asignacion con Id {docenteCurso.IdAsignacion}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar asignacion con Id {docenteCurso.IdAsignacion}: {ex.Message}", ex);
            }
        }*/

        public static async Task UpdateByCursoDocenteAsync(DocenteCursoDTO docenteCurso)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(
                    $"docentesCursos/{docenteCurso.IdCurso}/{docenteCurso.IdDocente}", docenteCurso);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar asignación. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar asignación: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar asignación: {ex.Message}", ex);
            }
        }
    }
}
