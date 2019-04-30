using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class VenueRoot
    {
        public Response response { get; set; }
        public static string GenerateURL (double latitud, double longitud)
        {
             var a= string.Format(Constants.VENUES_SEARCH, 
                latitud, 
                longitud,
                "YPAVJPWGFN134AUGU3D5GU4P1QMR1F25IA44NZF2DGM1B0V2",
                "C5NIYJ2RAG3YEWYQOTLC42HP0RIIITXDJSIZ35QYSGESWLRU", 
                DateTime.Now.ToString("yyyyMMdd"));
            return a;
        }
    }

   

    public class Location
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public double lat { get; set; }
        public double lng { get; set; } 
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; } 
    }

   

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
       
        public bool primary { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }

        public Location location { get; set; }
        public IList<Category> categories { get; set; }

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

   

public class Response
{
    public IList<Venue> venues { get; set; } 
}

}
