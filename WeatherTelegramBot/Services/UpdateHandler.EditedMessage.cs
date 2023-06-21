using Telegram.Bot.Types;
using Telegram.Bot;
using Serilog;

namespace WeatherTelegramBot.Services;

public partial class UpdateHandler
{
    private Task HandleEditedMessageUpdateAsync(ITelegramBotClient botClient, Message editedMessage, CancellationToken cancellationToken)
    {
        var username = editedMessage.From?.Username ?? editedMessage?.From?.FirstName;
        Log.Information("Received EditedMessage from {username}", username);
        throw new NotImplementedException();
    }
}
