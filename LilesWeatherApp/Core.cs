using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LilesWeatherApp;

namespace LilesWeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "e9c4194c3c11280dbfb1b6da25f1a208";
            string queryString = "https://api.openweathermap.org/data/2.5/weather?zip="
            + zipCode + ",us&appid=" + key + "&units=imperial";

            if(key != "e9c4194c3c11280dbfb1b6da25f1a208")
            {
                throw new ArgumentException("you must obtain an API key from " +
                                            "openweathermap.org/appid and save it in the 'key' var");

            }
            dynamic results = await
                     DataService.GetDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                Weather weather = new Weather
                {
                    Title = (string)results["name"],
                    Temperature = (string)results["main"]["temp"] + " F",
                    Wind = (string)results["wind"]["speed"] + " mph",
                    Humidity = (string)results["main"]["humidity"] + " %",
                    Visibility = (string)results["weather"][0]["main"]
                };
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
