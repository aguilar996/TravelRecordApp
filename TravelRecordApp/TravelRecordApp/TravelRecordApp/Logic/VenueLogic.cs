using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Newtonsoft.Json;

namespace TravelRecordApp.Logic
{
    public  class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double latitud, double longitud)
        {
            List<Venue> venues = new List<Venue>();
            var url = VenueRoot.GenerateURL(latitud, longitud);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
                venues = venueRoot.response.venues as List<Venue>;
            }
                return venues;
            
        }
    }
}
