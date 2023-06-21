using Telegram.Bot.Types;
using Telegram.Bot;
using Serilog;
using Telegram.Bot.Types.ReplyMarkups;

namespace WeatherTelegramBot.Services;

public partial class UpdateHandler
{
    private async Task HandleMessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        var username = message.From?.Username ?? message?.From?.FirstName;
        Log.Information("Received message from {username}", username);

        if(message.Text == "/start")
        {
            var sentMessage = await botClient.SendTextMessageAsync(
                chatId:message.Chat.Id,
                text:"Enter location!",
                replyMarkup: new ReplyKeyboardMarkup(new KeyboardButton("Location")
                {
                    RequestLocation = true
                }),cancellationToken:cancellationToken
                );



        }

     
    }
}
