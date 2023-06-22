using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, currentTime, condition, city, country, tempHigh, tempLow, 
            windSpeed, windDirection, precipitation, visibility, weather;
        public int icon;

        public Day()
        {
            date = currentTemp = currentTime = condition = city = country = tempHigh = tempLow
                = windSpeed = windDirection = precipitation = visibility = weather = "";
            icon = 0;
        }
    }
}
