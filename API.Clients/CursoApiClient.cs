using System.Net.Http.Headers;
using System.Net.Http.Json;
using DTOs;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;


namespace API.Cursos
{
    public class CursoApiClient
    {
        private static HttpClient client = new HttpClient();
        static CursoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5077/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<CursoDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("cursos/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CursoDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener curso con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener curso con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener curso con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<CursoDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("cursos");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CursoDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de cursos. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de cursos: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de cursos: {ex.Message}", ex);
            }
        }

        public static async Task<CursoDTO> AddAsync(CursoDTO curso)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("cursos", curso);

                if (response.IsSuccessStatusCode)
                {
                    var cursoCreado = await response.Content.ReadFromJsonAsync<CursoDTO>();
                    return cursoCreado;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear curso. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear curso: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear curso: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("cursos/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar curso con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar curso con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar curso con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(CursoDTO curso)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"cursos/{curso.IdCurso}", curso);


                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar curso con Id {curso.IdCurso}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar curso con Id {curso.IdCurso}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar curso con Id {curso.IdCurso}: {ex.Message}", ex);
            }
        }
        public static async Task BajarCupoAsync(CursoDTO curso)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"cursos/bajarCupo/{curso.IdCurso}", curso);


                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al bajar cupo del curso con Id {curso.IdCurso}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar curso con Id {curso.IdCurso}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar curso con Id {curso.IdCurso}: {ex.Message}", ex);
            }
        }

    }
}
