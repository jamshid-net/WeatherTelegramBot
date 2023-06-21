using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherTelegramBot.Models;

public class TheWeather
{
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("windspeed")]
    public double Windspeed { get; set; }

    [JsonPropertyName("winddirection")]
    public double Winddirection { get; set; }

    [JsonPropertyName("weathercode")]
    public int Weathercode { get; set; }

    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }
}
