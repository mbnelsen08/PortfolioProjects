using DrakkenheimEncountersBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading;
using System.Threading.Tasks;

namespace DrakkenheimEncountersBot
{
    internal class Program
    {
        static async Task Main(string[] args)
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

            await discord
                .ConnectAsync()
                .ConfigureAwait(false);

            // A cancellation token source is a special object that is passed to asynchronous methods
            // that is able to notify method that the user wishes to cancel the long running operation.
            // "Hey, my wife just went into labor, we're not making asynchronous breakfast anymore, we're leaving... NOW!"
            //
            // Not sure how to be implement this in the code base currently. We'd want to listen for some other event to
            // notify us to cancel. The Task.Delay(-1) is a really weird syntax...
            //
            // ex: cts.Cancel()
            var cts = new CancellationTokenSource();

            await Task
                .Delay(-1, cts.Token)
                .ConfigureAwait(false);
        }
    }
}
