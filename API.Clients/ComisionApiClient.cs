using System.Net.Http.Headers;
using System.Net.Http.Json;
using DTOs;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;


namespace API.Comisiones
{
    public class ComisionApiClient
    {
        private static HttpClient client = new HttpClient();
        static ComisionApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5077/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<ComisionDTO> GetAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("comisiones/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ComisionDTO>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener comision con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener comision con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener comision con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<ComisionDTO>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("comisiones");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ComisionDTO>>();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al obtener lista de comisiones. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de comisiones: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de comisiones: {ex.Message}", ex);
            }
        }

        public async static Task AddAsync(ComisionDTO comision)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("comisiones", comision);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear comision. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear comision: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al crear comision: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/comisiones/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar comision con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar comision con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar comision con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task UpdateAsync(ComisionDTO comision)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"comisiones/{comision.IdComision}", comision);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar comision con Id {comision.IdComision}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar comision con Id {comision.IdComision}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar comision con Id {comision.IdComision}: {ex.Message}", ex);
            }
        }
    }
}
