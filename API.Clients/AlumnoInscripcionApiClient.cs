using System.Net.Http.Headers;
using System.Net.Http.Json;
using DTOs;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;


namespace API.AlumnosInscripciones
{
    public class AlumnoInscripcionApiClient
    {
        private static HttpClient client = new HttpClient();
        static AlumnoInscripcionApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5077/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<AlumnoInscripcionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("alumnosInscripciones/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<AlumnoInscripcionDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener inscripcion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener inscripcion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener inscripcion con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("alumnosInscripciones");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<AlumnoInscripcionDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de inscripciones. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de inscripciones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de inscripciones: {ex.Message}", ex);
            }
        }

        public async static Task AddAsync(AlumnoInscripcionDTO alumnoInscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("alumnosInscripciones", alumnoInscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear inscripcion. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear inscripcion: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear inscripcion: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/alumnosInscripciones/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar inscripcion con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar inscripcion con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar inscripcion con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(AlumnoInscripcionDTO alumnoInscripcion)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"alumnosInscripciones/{alumnoInscripcion.IdInscripcion}", alumnoInscripcion);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar inscripcion con Id {alumnoInscripcion.IdInscripcion}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar inscripcion con Id {alumnoInscripcion.IdInscripcion}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar inscripcion con Id {alumnoInscripcion.IdInscripcion}: {ex.Message}", ex);
            }
        }
    }
}

