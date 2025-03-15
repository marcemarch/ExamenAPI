using ClienteAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClienteAPI.ConexionDatos
{
    public class RestConexionDatos : IRestConexionDatos
    {
        public readonly HttpClient httpClient;
        private readonly string dominio;
        private readonly string url;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        public RestConexionDatos()
        {
            httpClient = new HttpClient();
            dominio = "https://192.168.1.204:7124";
            //dominio = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7124" : "http://localhost:7124";
            url = $"{dominio}/api/plato";
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task AddPlatoAsync(Plato plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No hay conexión a internet");
                return;
            }
            try
            {
                string json = JsonSerializer.Serialize(plato, jsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[RED]: La respuesta no es exitosa (no es código 2XX)");
                }
                else
                {
                    Debug.WriteLine($"[RED]: La respuesta SÍ es exitosa (201)");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task DeletePlatoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No hay conexión a internet");
                return;
            }
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[RED]: La respuesta no es exitosa (no es código 2XX)");
                }
                else
                {
                    Debug.WriteLine($"[RED]: La respuesta SÍ es exitosa (204)");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<List<Plato>> GetPlatosAsync()
        {
            List<Plato> platos = new List<Plato>();
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No hay conexión a internet");
                return platos;
            }
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    platos = JsonSerializer.Deserialize<List<Plato>>(json, jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine($"[RED]: LA respuesta no es exitosa (no es código 2XX)");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
            return platos;
        }

        public  async Task UpdatePlatoAsync(Plato plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No hay conexión a internet");
                return;
            }
            try
            {
                string json = JsonSerializer.Serialize(plato, jsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{url}/{plato.Id}", content);
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[RED]: La respuesta no es exitosa (no es código 2XX)");
                }
                else
                {
                    Debug.WriteLine($"[RED]: La respuesta SÍ es exitosa (204)");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
