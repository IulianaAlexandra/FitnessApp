using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestXamarinApp.MuscleGroups
{
    class MuscleGroupsViewModel
    {
        public MuscleGroupsViewModel()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "MuscleGroup/list");
            Task.Run(() => this.GetAllMuscleGroupsAsync()).Wait();
        }

        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:5001/api/MuscleGroup/list";
        public async Task<List<MuscleGroupModel>> GetAllMuscleGroupsAsync()
        {
            var url = new Uri(baseUrl);
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<MuscleGroupModel>>(content);
            }
            return null;
        }
    }
}
