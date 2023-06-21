using Telegram.Bot.Types;
using Telegram.Bot;
using Serilog;

namespace WeatherTelegramBot.Services;

public partial class UpdateHandler
{
    private Task HandleMessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        var username = message.From?.Username ?? message?.From?.FirstName;
        Log.Information("Received message from {username}", username);
        return Task.CompletedTask;  
    }
}
