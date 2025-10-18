using System.Net.Http.Headers;
using System.Net.Http.Json;
using DTOs;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;


namespace API.Especialidades
{  
    public class EspecialidadApiClient
    {
        private static HttpClient client = new HttpClient();
        static EspecialidadApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5077/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<EspecialidadDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("especialidad/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EspecialidadDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener especialidad con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener especialidad con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener especialidad con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<EspecialidadDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("especialidades");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EspecialidadDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de especialidades. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de especialidades: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de especialidades: {ex.Message}", ex);
            }
        }

        public async static Task AddAsync(EspecialidadDTO especialidad)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("especialidades", especialidad);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear especialidad. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear especialidad: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear especialidad: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("especialidades/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar especialidad con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar especialidad con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar especialidad con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(EspecialidadDTO especialidad)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"especialidades/{especialidad.IdEspecialidad}", especialidad);


                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar especialidad con Id {especialidad.IdEspecialidad}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar especialidad con Id {especialidad.IdEspecialidad}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar especialidad con Id {especialidad.IdEspecialidad}: {ex.Message}", ex);
            }
        }
    }
}
