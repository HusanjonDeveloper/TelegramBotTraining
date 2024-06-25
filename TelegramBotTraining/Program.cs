using System.Net;
using JFA.Telegram.Console;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotTraining;
using File = System.IO.File;

// Telegram Bot Avto Test 

List<AvtoTestModel> model = new List<AvtoTestModel>();
string pathFile = "uzlotin.json";

var readFile = File.ReadAllText(path: pathFile);
var test = JsonConvert.DeserializeObject<List<AvtoTestModel>>(readFile);

var telegramBot = new TelegramBotManager();

var manager = telegramBot.Create("7121515784:AAHPWbbGkY9ERJ2j_N17mDMxJiPBFA8dH68");

telegramBot.Start(BotFunction);


void BotFunction(Update update)
{
    var message = update.Message;
    var chadId = update.Message?.From?.Id;

    for (int i = 0; i < 5; i++)
    {
        var buttons = new List<List<InlineKeyboardButton>>();

        foreach (var iteam in test![i].Choices)
        {
            var row = new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData($"\ud83d\udde3 {iteam.Text}")
            };
            buttons.Add(row);
        }
        manager.SendTextMessageAsync(chadId!,test[i].Question,  replyMarkup: new InlineKeyboardMarkup(buttons));
    }
}