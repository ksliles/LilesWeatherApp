namespace LilesWeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGetWeather_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(editZipCode.Text))
            {
                Weather weather = await Core.GetWeather(editZipCode.Text);
                if (weather != null)
                {
                    txtLocation.Text = weather.Title;
                    txtTemperature.Text = weather.Temperature;
                    txtWind.Text = weather.Wind;
                    txtVisibility.Text = weather.Visibility;
                    txtHumidity.Text = weather.Humidity;
                    txtSunrise.Text = weather.Sunrise;
                    txtSunset.Text = weather.Sunset;
                    btnGetWeather.Text = "Search Again";
                }
            }
        }

        
    }

}
