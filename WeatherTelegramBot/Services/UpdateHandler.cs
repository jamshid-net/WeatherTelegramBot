using Serilog;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WeatherTelegramBot.Services;

public partial class UpdateHandler : IUpdateHandler
{

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Log.Error(exception, "Error while polling telegram bot");
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handleTask = update.Type switch
        {
            UpdateType.Message => HandleMessageUpdateAsync(botClient, update.Message, cancellationToken),
            UpdateType.EditedMessage => HandleEditedMessageUpdateAsync(botClient, update.EditedMessage, cancellationToken),
            _ => HandleUnknownMessageUpdateAsync(botClient, update, cancellationToken)
        };
        try
        {
            await handleTask;
        }
        catch (Exception ex)
        {

            await HandlePollingErrorAsync(botClient, ex, cancellationToken);
        }


    }


    private Task HandleUnknownMessageUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Log.Information("Received {updateType} update.", update.Type);

        return Task.CompletedTask;
    }




}
