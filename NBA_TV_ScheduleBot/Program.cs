using NBA_TV_ScheduleBot.Configurations;
using NBA_TV_ScheduleBot.Services.RestServices;
using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace NBA_TV_ScheduleBot
{
    class Program
    {
        private static ITelegramBotClient botClient;
        private static TelegramCommandHandler commandHandler;

        static void Main()
        {
            Console.WriteLine("Starting");

            botClient = new TelegramBotClient(Configuration.GetTelegramAPIKey());
            commandHandler = new TelegramCommandHandler(botClient);

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Started");

            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message.Text))
            {
                return;
            }

            if (e.Message.Text.Contains("tv", StringComparison.InvariantCultureIgnoreCase))
            {
                await commandHandler.GetWeekSchedule(e);
            }
        }
    }
}
