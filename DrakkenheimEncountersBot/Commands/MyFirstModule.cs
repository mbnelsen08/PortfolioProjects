using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrakkenheimEncountersBot.Commands
{
    public class MyFirstModule : BaseCommandModule
    {
        [Command("helpme")]
        public async Task HelpCommand(CommandContext ctx)
        {
            string message = "The following are a list of all the commands available with the Drakkenheim Encounters Bot. \n All commands are preceded by '!', and [brackets] indicate a parameter you must enter. \n";
            message += "!greet [name] - greets the name you enter - ex. !roll Mark \n";
            message += "!roll [number of sides on dice] -  rolls 1 dice with the number of sides you specify = ex. !roll 20\n";
            message += "!roll [number of sides on dice] [number of dice] - rolls the number of dice you specify, each with the number of sides you specify - ex. !roll 20 2\n";
            message += "!encounter - generates a random encounter using all available encounters - ex. !encounter \n";
            message += "!encounter [location]- generates a random encounter in the location you specify - ex. !encounter sewers\n";
            await ctx.RespondAsync(message);
        }

        [Command("greet")]
        public async Task GreetCommand(CommandContext ctx, string name)
        {
            await ctx.RespondAsync($"Greetings, {name}! Are you ready to delve into the ruins of Drakkenheim?!");
        }

        [Command("roll")]
        public async Task RollADice(CommandContext ctx, int max)
        {
            var random = new Random();
            await ctx.RespondAsync($"You rolled: {random.Next(1, max+1)}");
        }

        [Command("roll")]
        public async Task RollADice(CommandContext ctx, int max, int num)
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
