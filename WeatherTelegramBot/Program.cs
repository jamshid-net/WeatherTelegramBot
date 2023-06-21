
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Polling;
using WeatherTelegramBot.BackgroundServices;
using WeatherTelegramBot.Services;

namespace WeatherTelegramBot;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console().MinimumLevel.Information()
            .CreateLogger();
        var builder = WebApplication.CreateBuilder(args);
       
        builder.Services.AddTransient<IUpdateHandler, UpdateHandler>();
        builder.Services.AddHostedService<BotBackgroundTask>();
        builder.Services.AddSingleton<ITelegramBotClient>(
             new TelegramBotClient(builder.Configuration.GetValue<string>("telegramBot")));
        

    
        var app = builder.Build();


        app.UseHttpsRedirection();

        app.UseAuthorization();


        

        app.Run();
    }
}
