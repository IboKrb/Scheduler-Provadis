using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ScheduleItem>> GetScheduleAsync()
        {
            var url = "https://provadis.sijamhodzic.de/schedule";
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ScheduleItem>>(url);
                return response;
            }
            catch (HttpRequestException e)
            {
                // Handle error (e.g., log or throw)
                throw;
            }
        }
    }
}
