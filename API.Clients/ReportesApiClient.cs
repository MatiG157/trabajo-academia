using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Reportes
{
    public static class ReportesApiClient
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5077/")
        };

        public static async Task<byte[]> GetReporteCursosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("reportes/cursos");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error {response.StatusCode}: {errorContent}");
                }
                
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener reporte de cursos: {ex.Message}", ex);
            }
        }

        public static async Task<byte[]> GetReportePlanesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("reportes/planes");
                
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error {response.StatusCode}: {errorContent}");
                }
                
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener reporte de planes: {ex.Message}", ex);
            }
        }
    }
}