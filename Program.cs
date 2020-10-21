using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelBot
{
    class Program
    {
        static TelegramBotClient bot; // создаем экземпляр бот

        static void Main(string[] args)
        {
            string token = System.IO.File.ReadAllText(@"F:\Telegram\token.txt"); // считываем инфу о токене

            bot = new TelegramBotClient(token); // инициализация бота через токен

            bot.StartReceiving(); // запуск бота

            // возможность получать сообщения
            bot.OnMessage += Bot_OnMessage;

            Console.ReadKey();
            bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, MessageEventArgs args) // args - входящее соощение
        {
            var msg = args.Message;
            Console.WriteLine(msg.Text); // показываем текст который был прислан

            if (msg.Text == "/menu") { MessageKeyboard(msg); }
            else { MessageWithoutKeyboard(msg); }

            //bot.SendTextMessageAsync(args.Message.Chat.Id, $"Вы прислали: {msg}");
        }

        static void MessageKeyboard(Message msg) //
        {
            var keys = new ReplyKeyboardMarkup( // набор кнопок
                new KeyboardButton[][]
                {
                    new KeyboardButton[]{ "Время", "Вторая кнопка в первом ряду"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                    new KeyboardButton[]{ "Второй ряд"},
                });

            bot.SendTextMessageAsync(
                chatId: msg.Chat.Id, // пользователь которому отправляем сообщение
                text: "Выбирайте: ",
                replyMarkup: keys
                );
        }

        static void MessageWithoutKeyboard(Message msg) //
        {
            var keys = new ReplyKeyboardRemove(); // набор кнопок
            string res = "Ответ";
            if (msg.Text == "Время")
            {
                res = DateTime.Now.ToString();
            }
            bot.SendTextMessageAsync(
                chatId: msg.Chat.Id, // пользователь которому отправляем сообщение
                text: $"{res}", // выборка
                                //text: $"Выбрано: {msg.Text}", // выборка
                replyMarkup: keys
                );
        }
    }
}
