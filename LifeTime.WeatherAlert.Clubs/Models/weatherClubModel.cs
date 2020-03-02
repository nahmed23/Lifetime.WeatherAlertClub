using System;
namespace LifeTime.WeatherAlert.Clubs.Models
{

    public class weatherClubModel


    {
        public DateTime date { get; set; }
        public int club_id { get; set; }
        public string club_code { get; set; }
        public string marketing_name { get; set; }
        public bool forecast { get; set; }
        public string outlook { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public bool clear_outlook { get; set; }
        public bool precip { get; set; }
        public bool severe { get; set; }
        public string wind_speed { get; set; }
    }
}
