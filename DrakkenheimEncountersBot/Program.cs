using DrakkenheimEncountersBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;

namespace DrakkenheimEncountersBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "OTQxNDIyNDAwODIwNjMzNzMx.YgVt7w.VAmodeNWLF0K4rAfBpbiAF95kXo",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] {"!"}
            });

            commands.RegisterCommands<MyFirstModule>();
            commands.RegisterCommands<RandomEncounterCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
