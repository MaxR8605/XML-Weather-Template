using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            day0temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].currentTemp))}°";
            day0lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempLow))}°";
            day0hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempHigh))}°";
            Form1.DetermineIcon(iconBox0, Form1.days[0].icon);

            day1temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[1].currentTemp))}°";
            day1lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[1].tempLow))}°";
            day1hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[1].tempHigh))}°";
            Form1.DetermineIcon(iconBox1, Form1.days[1].icon);

            day2temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[2].currentTemp))}°";
            day2lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[2].tempLow))}°";
            day2hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[2].tempHigh))}°";
            Form1.DetermineIcon(iconBox2, Form1.days[2].icon);

            day3temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[3].currentTemp))}°";
            day3lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[3].tempLow))}°";
            day3hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[3].tempHigh))}°";
            Form1.DetermineIcon(iconBox3, Form1.days[3].icon);

            day4temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[4].currentTemp))}°";
            day4lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[4].tempLow))}°";
            day4hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[4].tempHigh))}°";
            Form1.DetermineIcon(iconBox4, Form1.days[4].icon);

            day5temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[5].currentTemp))}°";
            day5lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[5].tempLow))}°";
            day5hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[5].tempHigh))}°";
            Form1.DetermineIcon(iconBox5, Form1.days[5].icon);

            day6temp.Text = $"{Math.Round(Convert.ToDouble(Form1.days[6].currentTemp))}°";
            day6lo.Text = $"{Math.Round(Convert.ToDouble(Form1.days[6].tempLow))}°";
            day6hi.Text = $"{Math.Round(Convert.ToDouble(Form1.days[6].tempHigh))}°";
            Form1.DetermineIcon(iconBox6, Form1.days[6].icon);

            daysLabel.Text = $"{Form1.days[0].date}\n\n{Form1.days[1].date}\n\n{Form1.days[2].date}\n\n{Form1.days[3].date}\n\n{Form1.days[4].date}\n\n{Form1.days[5].date}\n\n{Form1.days[6].date}";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
