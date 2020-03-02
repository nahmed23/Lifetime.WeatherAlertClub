using System;
using System.Collections.Generic;
using LifeTime.WeatherAlert.Clubs.Models;
using System.Data.SqlClient;

namespace LifeTime.WeatherAlert.Clubs.Repositories
{
    public class weatherClubRepository
    {
        public IEnumerable<weatherClubModel> getLatestWeatherAlert()
        {
            using (var conn = new SqlConnection("Server=clickstream-demo-server.database.windows.net,1433;Database=lt_clickstream_demo;User Id=ClickstreamUser;Password=clickstream_123;Trusted_Connection=False;Encrypt=True"))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM dbo.weather_club  WHERE date >= getdate() and severe =1", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new weatherClubModel
                            {
                                date = (DateTime)reader[0],
                                club_id = (int)reader[1],
                                club_code = (string)reader[2],
                                marketing_name = (string)reader[3],
                                forecast = Convert.ToBoolean((int)reader[4]),
                                outlook = (string)reader[5],
                                temp_min = (string)reader[6],
                                temp_max = (string)reader[7],
                                clear_outlook = Convert.ToBoolean((int)reader[8]),
                                precip = Convert.ToBoolean((int)reader[9]),
                                severe = Convert.ToBoolean((int)reader[10]),
                                wind_speed = (string)reader[11]
                            };
                        }
                        
                    }
                }
            }
        }
    }
}
