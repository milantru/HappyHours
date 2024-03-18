using HappyHoursData;
using HappyHoursData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static System.Net.WebRequestMethods;

namespace HappyHoursShared.Services
{
    public class WeatherForecastService
    {
        public async Task<WeatherForecast[]> GetWeatherForecastsAsync()
        {
            /* Android emulators do not run on the local machine 
             * and use a loopback IP (10.0.2.2) to communicate 
             * with the local machine... 
             * More here: https://learn.microsoft.com/en-us/aspnet/core/mobile/native-mobile-backend?view=aspnetcore-8.0#features */
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
                "http://10.0.2.2:5230" :
                "https://localhost:7059";
            var requestUri = new Uri(baseUrl + "/WeatherForecast");

            var forecasts = await GetAsync<WeatherForecast[]>(requestUri);

            return forecasts ?? Array.Empty<WeatherForecast>();
        }

        private async Task<T?> GetAsync<T>(Uri requestUri) where T : class
        {
            using var client = new HttpClient();

            var res = await client.GetAsync(requestUri);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            var serializedContent = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(serializedContent);
        }
    }
}
