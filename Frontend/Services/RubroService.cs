using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Frontend.Models;

namespace Frontend.Services
{
    public class RubroService
    {

        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5087/"; 
        public async Task<List<Rubro>> GetAllRubros(/*string token*/)
        {
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Rubro/Lista?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Rubro>>(contents);
            return APIResponse;
        }

        public async Task<Rubro> AddRubro(Rubro rubro, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Rubro>($"api/Rubro/AddRubro", rubro);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Rubro>(contents);
            return APIResponse;
        }

        public async Task<Rubro> GetRubroById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Rubro/GetRubroById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Rubro>(contents);
            return APIResponse;
        }

        public async Task UpdateRubro(int id, Rubro rubro, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Rubro>($"api/Rubro/UpdateRubro?id={id}", rubro);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteRubro(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Rubro/DeleteRubro?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
