
// dotnet add package Telegram.Bot
// создать папку внутри проекта photos
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

TelegramBotClient client = new TelegramBotClient("");

User user = await client.GetMeAsync();

Console.WriteLine(user.Username);

List<(long, string)> users = new List<(long, string)>();


while (true)
{
    Update[] updates = await client.GetUpdatesAsync();
    for (var i = 0; i < updates.Length; i++)
    {
        if (!users.Contains((updates[i].Message.From.Id, updates[i].Message.From.FirstName)))
        {
            users.Add((updates[i].Message.From.Id, updates[i].Message.From.FirstName));
        }

        if (updates[i].Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
        {

            if (updates[i].Message.Text == "хочу гуся")
            {
                StreamReader reader = new StreamReader("/Users/a2/RiderProjects/Lessons2/TgBot/photos/file_17.jpg");// укажите путь до файла
                await client.SendPhotoAsync(updates[i].Message.From.Id, reader.BaseStream);
            }

            if (updates[i].Message.Text == "всем гуся")
            {
                for (var j = 0; j < users.Count(); j++)
                {
                    StreamReader reader = new StreamReader("/Users/a2/RiderProjects/Lessons2/TgBot/photos/file_17.jpg");// укажите путь до файла
                    await client.SendPhotoAsync(users[j].Item1, reader.BaseStream);
                }
            }

            if (updates[i].Message.Text == "GET")
            {
                for (var j = 0; j < users.Count(); j++)
                {
                    await client.SendTextMessageAsync(updates[i].Message.From.Id, users[j].ToString());
                }
            }

            if (updates[i].Message.Text.Contains("SEND_PERSONAL"))
            {
                var strs = updates[i].Message.Text.Split(" ");
                StreamReader reader = new StreamReader("/Users/a2/RiderProjects/Lessons2/TgBot/photos/file_17.jpg"); // укажите путь до файла
                await client.SendPhotoAsync(strs[1], reader.BaseStream);
                //client.SendVideoAsync()
            }
        }
        //await client.SendTextMessageAsync(new ChatId(updates[i].Message.From.Id), updates[i].Message.Text);

        if (updates[i].Message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
        {
            var photos = updates[i].Message.Photo;

            for (var j = 0; j < photos?.Length; j++)
            {
                //var file  = await Telegram.Bot.TelegramBotClientExtensions.GetFileAsync(client,photos[j].FileId);
                var file = await client.GetFileAsync(photos[j].FileId);

                using (var saveImageStream = new FileStream($"./{file.FilePath}", FileMode.OpenOrCreate))
                {
                    Console.WriteLine(file.FilePath);
                    await client.DownloadFileAsync(file.FilePath, saveImageStream);
                    var sendingFile = new InputOnlineFile(saveImageStream);
                    StreamReader reader = new StreamReader($"./{file.FilePath}");

                    //Thread.Sleep(1500);
                    await client.SendPhotoAsync(updates[i].Message.From.Id, reader.BaseStream);
                }
            }
        }
    }



    if (updates.Length != 0)
    {
        updates = await client.GetUpdatesAsync(updates[updates.Length - 1].Id + 1);
    }
}
