using DrakkenheimEncountersBot.ZachStuff.Resources;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DrakkenheimEncountersBot.ZachStuff
{
    internal static class MyFirstModuleRefactor
    {
        // You can perform the rolling of the dice synchronously
        // You can leverage the power of LINQ and IEnumerables to simplify the code.
        // This can also be a private method because it is never used outside of this static class.
        private static string RollDice(int maximumPossibleRoll, int numberOfRolls)
        {
            // Create an IEnumerable (like an array) of all of the dice we're about to throw
            // Randomly roll each one of the dice based on the maximum roll
            var allRandomRolls = Enumerable
                .Range(0, numberOfRolls)
                .Select(_ => new Random().Next(1, maximumPossibleRoll));

            var sumOfRolls = allRandomRolls.Sum();
            var minimumRoll = allRandomRolls.Min();
            var maximumRoll = allRandomRolls.Max();

            // '$' lets us use variables/expressions inside of strings. This is called string interpolation
            // You are also able to use the '+' sign to concatenate strings on
            // different lines without having to reassign the variable.
            var message = $"You roll the following: " +
                $"{string.Join(" ,", allRandomRolls)} \n" +
                $"Sum: {sumOfRolls}, \n" +
                $"Max: {maximumRoll}, \n" +
                $"Min: {minimumRoll}";

            return message;
        }

        // Then we can do the asynchronous stuff here.
        // Single Responsibility Principle in action!
        // RollDice handles rolling of dice, RollCommand handles talking to Discord
        //
        // Notice we abstract the "roll" string into its own Constants folder so we know all
        // instances will be the same, and we can change them all in a single place.
        [Command(Constants.RollCommand)]
        public static async Task RollCommand(CommandContext contextt, int maximumRoll, int numberOfRolls = 1)
        {
            var resultOfRoll = RollDice(maximumRoll, numberOfRolls);

            await contextt
                .RespondAsync(resultOfRoll)
                .ConfigureAwait(false);
        }
    }
}
