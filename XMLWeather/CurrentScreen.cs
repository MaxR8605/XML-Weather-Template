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
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = $"{Form1.days[0].city}, {Form1.days[0].country}";
            currentOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].currentTemp))}°";
            minOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempLow))}°";
            maxOutput.Text = $"{Math.Round(Convert.ToDouble(Form1.days[0].tempHigh))}°";
            weatherLabel.Text = $"{Form1.days[0].weather} with {Form1.days[0].condition} and a {Form1.days[0].windSpeed}";
            Form1.DetermineIcon(iconBox, Form1.days[0].icon);
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
