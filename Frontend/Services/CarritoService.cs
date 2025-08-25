using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class CarritoService
    {

        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5206/";


        public CarritoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Carrito>> GetAllCarritos(/*string token*/)
        {
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Carrito?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Carrito>>(contents);
            return APIResponse;
        }

        public async Task<CarritoItem> AddProductoCarrito(CarritoItem item/*, string token*/)
        {
           // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CarritoItem>($"api/Carrito/AddProductoCarrito", item);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CarritoItem>(contents);
            return  APIResponse;
        }

        public async Task<Carrito> GetCarritoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Carrito/GetCarritoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Carrito>(contents);
            return APIResponse;
        }
        public async Task<Carrito> GetCarritoByCliente(long idCliente/*, string token*/)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Carrito/GetCarritoByCliente?idCliente={idCliente}");
                                                  
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Carrito>(contents);
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


        public async Task UpdateCarrito(long id, Carrito Carrito, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Carrito>($"api/Carrito/UpdateCarrito?id={id}", Carrito);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCarrito(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Carrito/DeleteCarrito?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
