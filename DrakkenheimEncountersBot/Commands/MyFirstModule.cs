using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DrakkenheimEncountersBot.Commands
{
    public class MyFirstModule : BaseCommandModule
    {
        // Classes represent schematics of an object. If a method doesn't rely on data from a specific instance/object,
        // you can mark the method as 'static', which is usually a performance benefit. Functional Programming uses only static methods.
        [Command("helpme")]
        public static async Task HelpCommand(CommandContext ctx)
        {
            string message = "The following are a list of all the commands available with the Drakkenheim Encounters Bot. \n All commands are preceded by '!', and [brackets] indicate a parameter you must enter. \n";
            message += "!greet [name] - greets the name you enter - ex. !greet Mark \n";
            message += "!roll [number of sides on dice] -  rolls 1 dice with the number of sides you specify = ex. !roll 20\n";
            message += "!roll [number of sides on dice] [number of dice] - rolls the number of dice you specify, each with the number of sides you specify - ex. !roll 20 2\n";
            message += "!encounter - generates a random encounter using all available encounters - ex. !encounter \n";
            message += "!encounter [location]- generates a random encounter in the location you specify - ex. !encounter sewers\n";
            await ctx.RespondAsync(message);
        }

        [Command("greet")]
        public static async Task GreetCommand(CommandContext ctx, string name)
        {
            await ctx.RespondAsync($"Greetings, {name}! Are you ready to delve into the ruins of Drakkenheim?!");
        }

        // This overload isn't needed because of optional parameters.
        // We can set the default to 1 if it isn't provided.
        [Command("roll")]
        public static async Task RollDice(CommandContext ctx, int max)
        {
            var random = new Random();
            await ctx.RespondAsync($"You rolled: {random.Next(1, max+1)}");
        }

        // Rolling a dice is inherntly NOT an asynchronous operation.
        // The only reason this is async is because of the CommandContext.
        // Is there a way we can split up the logic of the rolling a dice
        // with responding to the command context?
        [Command("roll")]
        public static async Task RollADice(CommandContext ctx, int max, int num = 1)
        {
            var random = new Random();
            string message = "You rolled the following: ";
            int sum = 0;
            int high = 0;
            int low = max;

            for(int i = 0; i < num; i++)
            {
                int roll = random.Next(1, max + 1);
                message += $"{roll} ";
                sum += roll;
                if(roll > high)
                {
                    high = roll;
                }
                if (roll< low)
                {
                    low = roll;
                }
            }

            message += $"\nSum: {sum}";
            message += $"\nHigh: {high}";
            message += $"\nLow: {low}";
            await ctx.RespondAsync(message);
        }
    }
}
