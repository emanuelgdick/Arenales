using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Services
{
    public class ProductoService
    {

        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5087/"; /* "http://mpiscicelli-002-site4.stempurl.com/"*/


        public ProductoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<IEnumerable<Producto>> GetAllProductos(string token)
        {
         //   _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productos?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<IEnumerable<Producto>>(contents);
            return APIResponse;
        }

        public async Task<Producto> AddProducto(Producto Producto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Producto>($"api/Productos/AddProducto", Producto);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Producto>(contents);
            return APIResponse;
        }

        public async Task<Producto> GetProductoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productos/GetProductoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Producto>(contents);
            return APIResponse;
        }

        public async Task<List<Color>> GetColoresByProducto(string codigo, long idTalle, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productos/GetColoresByProducto?codigo={codigo}&idTalle={idTalle}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Color>>(contents);
            return APIResponse;
        }


        public async Task UpdateProducto(long id, Producto Producto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Producto>($"api/Producto/UpdateProducto?id={id}", Producto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProducto(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Producto/DeleteProducto?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
