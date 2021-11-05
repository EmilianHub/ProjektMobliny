using Newtonsoft.Json;
using ProjektMobliny.Klucz;
using ProjektMobliny.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMobliny.Services
{
    public class ApiService
    {
        private JsonSerializer _serializer = new JsonSerializer();
        private static ApiService _ServiceClientInstance;
        public  static ApiService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiService();
                return _ServiceClientInstance;
            }
        }
        private HttpClient client;
        public ApiService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://maps.googleapis.com/maps/");
        }
        public async Task<GoogleDirection> GetDirection(string originLatitude, string originLongitude, string destinationLatitude, string destinationLongitude)
        {
            GoogleDirection googleDirection = new GoogleDirection();
           
                var response = await client.GetAsync($"api/directions/json?mode=driving&transit_routing_preference=less_driving&origin={originLatitude},{originLongitude}&destination={destinationLatitude},{destinationLongitude}&key={GoogleKey.Key}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        googleDirection = await Task.Run(() =>
                           JsonConvert.DeserializeObject<GoogleDirection>(json)
                        ).ConfigureAwait(false);

                    }
                }            

            return googleDirection;
        }
    }
    
}
