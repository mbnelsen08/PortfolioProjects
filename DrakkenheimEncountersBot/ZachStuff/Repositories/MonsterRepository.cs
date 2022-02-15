using DrakkenheimEncountersBot.ZachStuff.Extensions;
using DrakkenheimEncountersBot.ZachStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrakkenheimEncountersBot.ZachStuff.Repositories
{
    internal sealed class MonsterRepository
    {
        private static readonly IReadOnlyCollection<Monster> _monsters = new List<Monster>
        {
            Monster.Create(
                MonsterName.Create("Baby Spider"),
                MonsterDescription.Create("Itty Bitty Spider"),
                MonsterType.Create(MonsterKind.Monster)),
            Monster.Create(
                MonsterName.Create("Adolescent Spider"),
                MonsterDescription.Create("Bitty Spider"),
                MonsterType.Create(MonsterKind.Monster)),
            Monster.Create(
                MonsterName.Create("Adult Spider"),
                MonsterDescription.Create("Daddy Spider"),
                MonsterType.Create(MonsterKind.Monster)),
            Monster.Create(
                MonsterName.Create("Rat"),
                MonsterDescription.Create("Loves cheese and femurs"),
                MonsterType.Create(MonsterKind.Monster)),
            Monster.Create(
                MonsterName.Create("Mouse"),
                MonsterDescription.Create("Loves cheese more than femurs."),
                MonsterType.Create(MonsterKind.Monster)),
            Monster.Create(
                MonsterName.Create("Vermin"),
                MonsterDescription.Create("Loves femurs more than cheese."),
                MonsterType.Create(MonsterKind.Monster)),
            Monster.Create(
                MonsterName.Create("Bandit"),
                MonsterDescription.Create("Gimme da casssshhhh"),
                MonsterType.Create(MonsterKind.Queens)),
            Monster.Create(
                MonsterName.Create("Vin Diesel"),
                MonsterDescription.Create("You could hurt someone with that. Good thing it's not loaded."),
                MonsterType.Create(MonsterKind.Queens)),
        };

        internal static IReadOnlyCollection<Monster> Monsters => _monsters;

        // I wanna get all the spiders, so I'm making sure I'm getting back a subset of the monsters
        // Where the MonsterKind Enum is Monster and I'm doing a case INSENSITIVE comparison to see if the 
        // name contains Spider.
        //
        // I like IReadOnlyCollection because I don't want calling code to mutate my repository. 
        // It'll take what I have and like it!
        internal static IReadOnlyCollection<Monster> Spiders => Monsters
            .Where(monster => monster.Type.Value == MonsterKind.Monster
                && monster.Name.Value.Contains("spider", StringComparison.OrdinalIgnoreCase))
            .ToReadOnlyCollection();

        internal static IReadOnlyCollection<Monster> CheeseLovingCritters => Monsters
            .Where(monster => monster.Type.Value == MonsterKind.Monster
                && monster.Description.Value.Contains("cheese", StringComparison.OrdinalIgnoreCase))
            .ToReadOnlyCollection();

        internal static IReadOnlyCollection<Monster> FifthElementers => Monsters
            .Where(monster => monster.Type.Value == MonsterKind.Queens)
            .ToReadOnlyCollection();

        // Notice how we are creating methods to perform the filtering so that calling code doesn't necessarily
        // need to do it. They are still able to if they want, but if we know the most common search criteria,
        // we can make the calling code look a lot cleaner.
    }
}
