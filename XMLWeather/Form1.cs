using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects
        public static List<Day> days = new List<Day>();

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                //TODO: create a day object
                Day day = new Day();
                //TODO: fill day object with required data
                reader.ReadToFollowing("time");
                day.date = reader.GetAttribute("day");

                reader.ReadToFollowing("symbol");
                day.icon = Convert.ToInt16(reader.GetAttribute("number"));
                reader.ReadToFollowing("temperature");
                day.currentTemp = reader.GetAttribute("day");
                day.tempLow = reader.GetAttribute("min");
                day.tempHigh = reader.GetAttribute("max");
                //TODO: if day object not null add to the days list
                if (day.date != null)
                {
                    days.Add(day);
                }
            }
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list
            reader.ReadToFollowing("city");
            days[0].city = reader.GetAttribute("name");
            reader.ReadToDescendant("country");
            days[0].country = reader.ReadString();

            reader.ReadToFollowing("temperature");
            days[0].currentTemp = reader.GetAttribute("value");
            days[0].tempLow = reader.GetAttribute("min");
            days[0].tempHigh = reader.GetAttribute("max");

            reader.ReadToFollowing("wind");
            reader.ReadToDescendant("speed");
            days[0].windSpeed = reader.GetAttribute("name");

            reader.ReadToFollowing("clouds");
            days[0].condition = reader.GetAttribute("name");

            reader.ReadToFollowing("weather");
            days[0].icon = Convert.ToInt16(reader.GetAttribute("number"));
            days[0].weather = reader.GetAttribute("value");

            days[0].condition = days[0].condition.ToLower();
            days[0].windSpeed = days[0].windSpeed.ToLower();
        }

        public static void DetermineIcon(PictureBox box, int iconNumber)
        {
            if (iconNumber < 300)
            {
                box.Image = Properties.Resources.thunderstorm;
            }
            else if (iconNumber < 400)
            {
                box.Image= Properties.Resources.rain;
            }
            else if (iconNumber < 600)
            {
                if (iconNumber < 511)
                {
                    box.Image = Properties.Resources.sunWithRainCloud;
                }
                else if (iconNumber > 511)
                {
                    box.Image = Properties.Resources.rain;
                }
                else
                {
                    box.Image = Properties.Resources.snow;
                }
            }
            else if(iconNumber < 700)
            {
                box.Image = Properties.Resources.snow;
            }
            else if (iconNumber < 800)
            {
                box.Image = Properties.Resources.fog;
            }
            else if (iconNumber == 800)
            {
                box.Image = Properties.Resources.sun;
            }
            else
            {
                if (iconNumber == 801)
                {
                    box.Image = Properties.Resources.sunWithCloud;
                }
                else
                {
                    box.Image = Properties.Resources.clouds;
                }
            }
        }
    }
}
