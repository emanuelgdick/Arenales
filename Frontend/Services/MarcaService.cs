using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Services
{
    public class MarcaService
    {

        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5087/"; /* "http://mpiscicelli-002-site4.stempurl.com/"*/


        public MarcaService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Marca>> GetAllMarcas(/*string token*/)
        {
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Marcas?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Marca>>(contents);
            return APIResponse;
        }

        public async Task<Marca> AddMarca(Marca Marca, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Marca>($"api/Marca/AddMarca", Marca);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Marca>(contents);
            return APIResponse;
        }

        public async Task<Marca> GetMarcaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Marca/GetMarcaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Marca>(contents);
            return APIResponse;
        }

        public async Task UpdateMarca(long id, Marca Marca, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Marca>($"api/Marca/UpdateMarca?id={id}", Marca);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMarca(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Marca/DeleteMarca?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
