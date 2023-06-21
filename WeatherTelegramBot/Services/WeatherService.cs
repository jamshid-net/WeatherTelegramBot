using BetterConsoles.Tables;
using WeatherTelegramBot.Models;

namespace WeatherTelegramBot.Services;

public class WeatherService
{
    private readonly HttpClient _openMeteoClient;

    public WeatherService(IHttpClientFactory openMeteoClient)
    {
        _openMeteoClient = openMeteoClient.CreateClient("OpenMeteoClient");
    }

    public async Task<string> GetWeatherStringAsync(double latitude, double longitude,CancellationToken cancellationToken = default)
    {
        var route = $"v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";
        var weather = await _openMeteoClient.GetFromJsonAsync<TheWeather>(route,cancellationToken);


        var emojies = weather?.Temperature switch
        {
            >= 50 => "🔥",
            >= 30 => "☀️",
            >= 5 => "❄️",
            _ => "🥶"


        };
        Table table = new Table("Weather now!");
        table.AddRow($"{weather.Temperature:F1} {emojies}");
        table.AddRow($"{weather.Windspeed} km/s");

        return table.ToString();
    }

}
