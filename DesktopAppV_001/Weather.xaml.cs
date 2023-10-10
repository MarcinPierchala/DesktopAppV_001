using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows;

namespace DesktopAppV_001
{
    /// <summary>
    /// Interaction logic for Weather.xaml
    /// </summary>
    public partial class Weather : Window
    {
        public Weather()
        {
            InitializeComponent();
        }

        string Apikey = ApplicationData.ApiKeyStored;

        private void btn_search_weather_Click(object sender, RoutedEventArgs e)
        {
            if(tb_city.Text.Length > 0)
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", tb_city.Text, Apikey);
                        var json = wc.DownloadString(url);
                        WeatherData.root Info = JsonConvert.DeserializeObject<WeatherData.root>(json);
                        tb_temp.Text = (Math.Round((Info.main.temp - 273.15),1)).ToString() + " \u00B0" + "C";
                        tb_cloud.Text = Info.weather[0].description.ToUpper();
                        tb_humid.Text = Info.main.humidity.ToString() + " %";
                        tb_wind.Text = Info.wind.speed.ToString() + " m/s";

                    }
                }
                catch(System.Net.WebException webError) 
                {
                    MessageBox.Show($"Wystąpił błąd: '{webError}'\n!!!SKONTAKTUJ SIĘ Z DOSTAWCĄ USŁUGI LUB ADMINISTRATOREM!!!");
                }
                catch(IOException errMessage)
                {
                    MessageBox.Show($"Wystąpił błąd: '{errMessage}'");
                }
                
            }
            

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
