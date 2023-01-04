using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Data.Interfaces;
using Domain.Models;

namespace Data
{
    public class Repository : IRepository
    {
        private const string APIURL = "https://api.covid19api.com/summary";
        private static HttpClient _httpClient = new HttpClient();
        public async Task<Summary> GetSummary()
        {
            var response = await _httpClient.GetAsync(APIURL);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBodyString = await response.Content.ReadAsStringAsync();
            Summary summary = JsonConvert.DeserializeObject<Summary>(responseBodyString);

            return summary;
        }
    }
}