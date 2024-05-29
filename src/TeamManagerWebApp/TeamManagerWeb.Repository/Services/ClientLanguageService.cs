using System.Net.Http.Json;
using TeamManagerWeb.Core.Entities;

namespace TeamManagerWeb.Repository.Services
{
    public class ClientLanguageService 
    {
        private readonly HttpClient _httpClient;

        public ClientLanguageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Language> AddLanguage(Language language)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/language", language);
            return await result.Content.ReadFromJsonAsync<Language>();
        }

        public async Task<bool> DeleteLanguage(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/language/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<Language> EditLanguage(int id, Language language)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/language/{id}", language);
            return await result.Content.ReadFromJsonAsync<Language>();
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Language>>("/api/language");
            return result;
        }

        public async Task<Language> GetLanguageById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Language>($"/api/language/{id}");
            return result;
        }
    }
}
