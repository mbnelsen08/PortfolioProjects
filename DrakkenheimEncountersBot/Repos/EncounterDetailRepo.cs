using DrakkenheimEncountersBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Repos
{
    public class EncounterDetailRepo
    {
        private static List<EncounterDetails> Details = new List<EncounterDetails>
        {
            new EncounterDetails{ ID=1, DiceSides=1, Dice=1, MonsterName="Mage"},
            new EncounterDetails{ ID=1, DiceSides=4, Dice=1, MonsterName="Hedge Wizard(s)"},
            new EncounterDetails{ ID=2, DiceSides=4, Dice=1, MonsterName="Mimic(s)"},
            new EncounterDetails{ ID=3, DiceSides=1, Dice=1, MonsterName="Chimera"},
            new EncounterDetails{ ID=4, DiceSides=1, Dice=1, MonsterName="Gelatinous Cube"},
            new EncounterDetails{ ID=5, DiceSides=1, Dice=1, MonsterName="Crimson Countess"},
            new EncounterDetails{ ID=5, DiceSides=4, Dice=2, MonsterName="Harpies"},
            new EncounterDetails{ ID=6, DiceSides=1, Dice=1, MonsterName="Haze Hulk"},
            new EncounterDetails{ ID=7, DiceSides=1, Dice=1, MonsterName="Chuul"},
            new EncounterDetails{ ID=7, DiceSides=6, Dice=3, MonsterName="Aquatic Delerium Dregs"},
            new EncounterDetails{ ID=9, DiceSides=6, Dice=3, MonsterName="Haze Hulks"},
            new EncounterDetails{ ID=11, DiceSides=4,Dice=2, MonsterName="Haze Wights"},
            new EncounterDetails{ ID=12, DiceSides=6,Dice=3, MonsterName="Garmyr"},
            new EncounterDetails{ ID=12, DiceSides=4,Dice=1, MonsterName="Worg(s)"},
            new EncounterDetails{ ID=13, DiceSides=6,Dice=2, MonsterName="Garmyr Berserkers"},
            new EncounterDetails{ ID=13, DiceSides=4,Dice=1, MonsterName="Hell Hound(s)"},
            new EncounterDetails{ ID=14, DiceSides=4,Dice=1, MonsterName="Will-O-Wisp(s)"},
            new EncounterDetails{ ID=15, DiceSides=4,Dice=1, MonsterName="Gibbering Mouther(s)"},
            new EncounterDetails{ ID=16, DiceSides=1,Dice=1, MonsterName="Cloaker"},
            new EncounterDetails{ ID=18, DiceSides=6,Dice=3, MonsterName="Harpies"},
            new EncounterDetails{ ID=19, DiceSides=1,Dice=1, MonsterName="Haze Wight"},
            new EncounterDetails{ ID=19, DiceSides=6,Dice=3, MonsterName="Haze Hulks"},
            new EncounterDetails{ ID=20, DiceSides=1,Dice=1, MonsterName="Warp Witch"},
            new EncounterDetails{ ID=21, DiceSides=1,Dice=1, MonsterName="Urban Ranger"},
            new EncounterDetails{ ID=21, DiceSides=4,Dice=2, MonsterName="Scouts"},
            new EncounterDetails{ ID=23, DiceSides=4,Dice=1, MonsterName="Delerium Elementals"},
            new EncounterDetails{ ID=24, DiceSides=1,Dice=1, MonsterName="Lord of the Feast"},
            new EncounterDetails{ ID=24, DiceSides=6,Dice=3, MonsterName="Garmyr"},
            new EncounterDetails{ ID=24, DiceSides=4,Dice=2, MonsterName="Hell Hounds"},
            new EncounterDetails{ ID=25, DiceSides=6,Dice=3, MonsterName="Delerium Dregs"},
            new EncounterDetails{ ID=26, DiceSides=4,Dice=1, MonsterName="Arcane Wraith(s)"},
            new EncounterDetails{ ID=27, DiceSides=1,Dice=1, MonsterName="Manticore"},
            new EncounterDetails{ ID=28, DiceSides=1,Dice=1, MonsterName="Ochre Jelly"},
            new EncounterDetails{ ID=29, DiceSides=1,Dice=1, MonsterName="Shambling Mound(s)"},
            new EncounterDetails{ ID=29, DiceSides=4,Dice=1, MonsterName="Hypnotic Eldritch Blossoms"},
            new EncounterDetails{ ID=30, DiceSides=4,Dice=1, MonsterName="Phase Spiders"},
            new EncounterDetails{ ID=31, DiceSides=6,Dice=3, MonsterName="Cultists"},
            new EncounterDetails{ ID=31, DiceSides=1,Dice=1, MonsterName="Cult Fanatic"},
            new EncounterDetails{ ID=31, DiceSides=1,Dice=1, MonsterName="Berserker"},
            new EncounterDetails{ ID=32, DiceSides=1,Dice=1, MonsterName="Bandit Captain"},
            new EncounterDetails{ ID=32, DiceSides=6,Dice=2, MonsterName="Bandits"},
            new EncounterDetails{ ID=33, DiceSides=1,Dice=1, MonsterName="Knight"},
            new EncounterDetails{ ID=33, DiceSides=1,Dice=1, MonsterName="Warhorse"},
            new EncounterDetails{ ID=33, DiceSides=6,Dice=2, MonsterName="Guards"},
            new EncounterDetails{ ID=34, DiceSides=1,Dice=1, MonsterName="Warlock of the Ratling God"},
            new EncounterDetails{ ID=34, DiceSides=6,Dice=6, MonsterName="Ratlings"},
            new EncounterDetails{ ID=37, DiceSides=1,Dice=1, MonsterName="Otyugh"},
            new EncounterDetails{ ID=38, DiceSides=4,Dice=2, MonsterName="Shadows"},
            new EncounterDetails{ ID=39, DiceSides=6,Dice=2, MonsterName="Haze Husks"},
            new EncounterDetails{ ID=40, DiceSides=6,Dice=4, MonsterName="Ratlings"},
            new EncounterDetails{ ID=40, DiceSides=4,Dice=2, MonsterName="Ratling Guttersnipes"},
            new EncounterDetails{ ID=41, DiceSides=1,Dice=1, MonsterName="Troll"},
            new EncounterDetails{ ID=44, DiceSides=4,Dice=1, MonsterName="Wall Gargoyle(s)"},
            new EncounterDetails{ ID=46, DiceSides=1,Dice=1, MonsterName="Protean Abomination"},
            new EncounterDetails{ ID=47, DiceSides=6,Dice=3, MonsterName="Haze Wights"},
            new EncounterDetails{ ID=47, DiceSides=4,Dice=1, MonsterName="Additional Haze Wight(s)"},
            new EncounterDetails{ ID=48, DiceSides=1,Dice=1, MonsterName="Warp Witch"},
            new EncounterDetails{ ID=48, DiceSides=4,Dice=1, MonsterName="Additional Warp Witch(es)"},
            new EncounterDetails{ ID=49, DiceSides=6,Dice=3, MonsterName="Delerium Dregs"},
            new EncounterDetails{ ID=49, DiceSides=4,Dice=1, MonsterName="Haze Hulks"},
            new EncounterDetails{ ID=50, DiceSides=4,Dice=2, MonsterName="Manticores"},
            new EncounterDetails{ ID=51, DiceSides=4,Dice=1, MonsterName="Black Pudding(s)"},
            new EncounterDetails{ ID=52, DiceSides=6,Dice=2, MonsterName="Phase Spiders"},
            new EncounterDetails{ ID=53, DiceSides=4,Dice=2, MonsterName="Shadows"},
            new EncounterDetails{ ID=53, DiceSides=1,Dice=1, MonsterName="Arcane Wraith"},
            new EncounterDetails{ ID=54, DiceSides=1,Dice=3, MonsterName="Trolls"},
            new EncounterDetails{ ID=55, DiceSides=6,Dice=2, MonsterName="Wall Gargoyles"},
            new EncounterDetails{ ID=56, DiceSides=6,Dice=6, MonsterName="Garmyr"},
        };

        public List<EncounterDetails> GetAllDetails()
        {
            return Details;
        }
    }
}
