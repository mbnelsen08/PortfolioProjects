using DrakkenheimEncountersBot.Models;
using DrakkenheimEncountersBot.Repos;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakkenheimEncountersBot.Commands
{
    public class RandomEncounterCommands : BaseCommandModule
    {
        [Command("encounter")]
        public async Task RandomEncounter(CommandContext ctx)
        {
            var repo = new EncounterRepo();
            Encounter encounter = new Encounter();
            List<Encounter> encounters = repo.GetAllEncounters();

            do
            {
                var random = new Random();
                int num = random.Next(1, 56);
                encounter = encounters.FirstOrDefault(e => e.ID == num);
            } while (encounter == null);

            CommonLocation commonLocation = GetRandomLocation();
            LuckyFinds find = GetRandomFind();
            WarpedRuins ruin = GetRandomRuins();

            DiscordEmbed embed = GetEncounterEmbed(encounter, commonLocation, find, ruin);

            await ctx.RespondAsync(embed);
        }

        [Command("encounter")]
        public async Task RandomEncounter(CommandContext ctx, string location)
        {
            location = location.ToLower();
            var repo = new EncounterRepo();
            Encounter encounter = new Encounter();
            List<Encounter> encounters = new List<Encounter>();

            // Switch Expressions (as opposed to switch case statements)
            // This is a way you can use pattern matching as an expression rather than as a statement.
            // My preferred way of doing the logic you have below.
            // The '_' means 'all other cases not explicitly covered'
            // All cases must return the same type, in this case, List<Encounter>
            // We can then use the variable later however we want.
            // 
            //var switchExpression = location switch
            //{
            //    "sewers" => repo.GetSewerEncounters(),
            //    "inner" => repo.GetInnerEncounters(),
            //    "outer" => repo.GetOuterEncounters(),
            //    _ => Array.Empty<Encounter>().ToList(),
            //};

            switch (location)
            {
                case "sewers":
                    encounters = repo.GetSewerEncounters();
                    break;
                case "inner":
                    encounters = repo.GetInnerEncounters();
                    break;
                case "outer":
                    encounters = repo.GetOuterEncounters();
                    break;
                default:
                    await ctx.RespondAsync("Not a valid location. Use one of the following: \n !encounters sewers, !encounters outer, or !encounters inner");
                    break;
            }

            do
            {
                var random = new Random();
                int num = random.Next(1, 56);
                encounter = encounters.FirstOrDefault(e => e.ID == num);
            } while (encounter == null);

            CommonLocation commonLocation = GetRandomLocation();
            LuckyFinds find = GetRandomFind();
            WarpedRuins ruin = GetRandomRuins();

            DiscordEmbed embed = GetEncounterEmbed(encounter, commonLocation, find, ruin);

            await ctx.RespondAsync(embed);
        }
        [Command("npc")]
        public async Task RandomNpc(CommandContext ctx)
        {
            var repo = new NpcRepo();
            NPC npc = new NPC();
            List<NPC> npcs = repo.GetAllNpcs();

            do
            {
                var random = new Random();
                int num = random.Next(1, 50);
                npc = npcs.FirstOrDefault(n => n.ID == num);
            } while(npc == null);

            DiscordEmbed embed = GetNpcEmbed(npc);

            await ctx.RespondAsync(embed);
        }

        [Command("npc")]
        public async Task RandomNpc(CommandContext ctx, string faction)
        {
            var repo = new NpcRepo();
            NPC npc = new NPC();
            List<NPC> npcs = new List<NPC>();
            faction = faction.ToLower();

            switch (faction)
            {
                case "academy":
                    npcs = repo.GetFactionNpcs("The Amethyst Academy");
                    break;
                case "lanterns":
                    npcs = repo.GetFactionNpcs("The Hooded Lanterns");
                    break;
                case "followers":
                    npcs = repo.GetFactionNpcs("The Followers of the Falling Fire");
                    break;
                case "silver":
                    npcs = repo.GetFactionNpcs("Knights of the Silver Order");
                    break;
                case "queens":
                    npcs = repo.GetFactionNpcs("Queen's Men");
                    break;
                default:
                    await ctx.RespondAsync("Not a valid faction. Use one of the following: \n !npc academy, !npc lanterns, !npc followers, !npc silver, or !npc queens");
                    break;
            }

            do
            {
                var random = new Random();
                int num = random.Next(1, 50);
                npc = npcs.FirstOrDefault(n => n.ID == num);
            } while (npc == null);

            DiscordEmbed embed = GetNpcEmbed(npc);

            await ctx.RespondAsync(embed);
        }

        public DiscordEmbed GetEncounterEmbed(Encounter encounter, CommonLocation commonLocation, LuckyFinds find, WarpedRuins ruin)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = encounter.Name;
            embed.Description = encounter.Description;
            embed.Color = DiscordColor.Blue;

            if (encounter.MonsterType != "none")
            {
                var detailRepo = new EncounterDetailRepo();
                List<EncounterDetails> allDetails = detailRepo.GetAllDetails();
                List<EncounterDetails> encounterDetails = allDetails.FindAll(d => d.ID == encounter.ID);
                string monsters = "";
                foreach (EncounterDetails details in encounterDetails)
                {
                    var random = new Random();
                    int sum = 0;

                    for (int i = 0; i < details.Dice; i++)
                    {
                        int roll = random.Next(1, details.DiceSides + 1);
                        sum += roll;
                    }
                    monsters+= $"{sum} {details.MonsterName}\n";
                }
                embed.AddField("Monster(s)", monsters);
                embed.Color = DiscordColor.Red;
                if(encounter.MonsterType != "monster")
                {
                    embed.Color = DiscordColor.Green;
                    var repo = new NpcRepo();
                    NPC npc = new NPC();
                    List<NPC> npcs = new List<NPC>();
                    switch (encounter.MonsterType)
                    {
                        case "academy":
                            npcs = repo.GetFactionNpcs("The Amethyst Academy");
                            break;
                        case "lanterns":
                            npcs = repo.GetFactionNpcs("The Hooded Lanterns");
                            break;
                        case "followers":
                            npcs = repo.GetFactionNpcs("The Followers of the Falling Fire");
                            break;
                        case "silver":
                            npcs = repo.GetFactionNpcs("Knights of the Silver Order");
                            break;
                        case "queens":
                            npcs = repo.GetFactionNpcs("Queen's Men");
                            break;
                    }
                    do
                    {
                        var random = new Random();
                        int num = random.Next(1, 50);
                        npc = npcs.FirstOrDefault(n => n.ID == num);
                    } while (npc == null);
                    embed.AddField("NPC", npc.Name + "\n" + npc.Description);
                }
            }
            embed.AddField("Optional Flavor", "Common Location:\n" + commonLocation.Description + "\n" + "Warped Ruins:\n" + ruin.Description + "\n" + "Lucky Find:\n" + find.Description);
            return embed;
        }
        public DiscordEmbed GetNpcEmbed(NPC npc)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = npc.Name +" || " + npc.StatBlock;
            embed.Description = npc.Description;
            embed.AddField("Faction", npc.Faction);
            embed.Color = DiscordColor.Purple;
            return embed;
        }

        public CommonLocation GetRandomLocation()
        {
            CommonLocationsRepo repo = new CommonLocationsRepo();
            List<CommonLocation> locations = repo.GetAllLocations();
            CommonLocation location = new CommonLocation();
            var random = new Random();
            int num = random.Next(1, 20);

            do
            {
                num = random.Next(1, 20);
                location = locations.FirstOrDefault(l => l.ID == num);
            } while (location == null);

            return location;
        }

        public WarpedRuins GetRandomRuins()
        {
            WarpedRuinsRepo repo = new WarpedRuinsRepo();
            List<WarpedRuins> ruins = repo.GetWarpedRuins();
            WarpedRuins ruin = new WarpedRuins();
            var random = new Random();
            int num = random.Next(1, 20);

            do
            {
                num = random.Next(1, 20);
                ruin = ruins.FirstOrDefault(l => l.ID == num);
            } while (ruin == null);

            return ruin;
        }

        public LuckyFinds GetRandomFind()
        {
            LuckyFindsRepo repo = new LuckyFindsRepo();
            List<LuckyFinds> finds = repo.GetLuckFinds();
            LuckyFinds find = new LuckyFinds();
            var random = new Random();
            int num = random.Next(1, 20);

            do
            {
                num = random.Next(1, 20);
                find = finds.FirstOrDefault(l => l.ID == num);
            } while (find == null);

            return find;
        }
    }
}
