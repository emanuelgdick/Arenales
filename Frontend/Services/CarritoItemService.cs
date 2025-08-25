using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class CarritoItemService
    {

        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5206/";

        public CarritoItemService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<CarritoItem>> GetAllCarritoItems(/*string token*/)
        {
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/CarritoItem?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<CarritoItem>>(contents);
            return APIResponse;
        }

        public async Task<CarritoItem> AddProductoCarritoItem(CarritoItem item/*, string token*/)
        {
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CarritoItem>($"api/CarritoItem/Crear", item);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CarritoItem>(contents);
            return APIResponse;
        }

        public async Task<CarritoItem> UpdateProductoCarritoItem(int id,CarritoItem item/*, string token*/)
        {
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CarritoItem>($"api/CarritoItem/Editar", item);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CarritoItem>(contents);
            return APIResponse;
        }

        public async Task<CarritoItem> GetCarritoItemById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/CarritoItem/GetCarritoItemById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CarritoItem>(contents);
            return APIResponse;
        }
        public async Task<CarritoItem> GetCarritoItemByCliente(long idCliente/*, string token*/)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/CarritoItem/GetCarritoItemByCliente?idCliente={idCliente}");

            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CarritoItem>(contents);
            return APIResponse;
            //try
            //{
            //    
            //}
            //catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}

            //return null;// APIResponse;
        }

        public async Task UpdateCarritoItem(long id, CarritoItem CarritoItem, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CarritoItem>($"api/CarritoItem/UpdateCarritoItem?id={id}", CarritoItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCarritoItem(long id/*, string token*/)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/CarritoItem/Eliminar?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
