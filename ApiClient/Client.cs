using FitnessAppWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiClient
{
    public class Client 
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://localhost:5001/api";

        public Client()
        {
            _httpClient = new HttpClient();
        }


        public async Task<T> Get<T>(string path)
        {
            var fullUrl = $"{baseUrl}{path}";
            var response = await _httpClient.GetAsync(fullUrl);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseBody = JsonConvert.DeserializeObject<T>(responseContent);

            return responseBody;
        }

        public async Task Post<T>(string path, T payload)
        {
            var fullUrl = $"{baseUrl}{path}";
            var stringPayload = JsonConvert.SerializeObject(payload);
            var buffer = System.Text.Encoding.UTF8.GetBytes(stringPayload);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await _httpClient.PostAsync(fullUrl, byteContent);
        }
    }
}
