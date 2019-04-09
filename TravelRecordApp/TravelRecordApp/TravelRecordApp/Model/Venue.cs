using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {
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
}
