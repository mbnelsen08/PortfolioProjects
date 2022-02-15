using DrakkenheimEncountersBot.Models;
using System.Collections.Generic;

namespace DrakkenheimEncountersBot.Repos
{
    public class EncounterRepo
    {
#pragma warning disable IDE1006 // Naming Styles
        private static List<Encounter> Encounters = new List<Encounter>
#pragma warning restore IDE1006 // Naming Styles
        {
            new Encounter {ID = 1,Location="outer-inner", MonsterType = "academy", Name = "Academy Surveyor", Description = "An Amethyst Academy mage and several apprentices are conducting research in the ruins."},
            new Encounter {ID = 2,Location="outer", MonsterType = "monster", Name = "Angry Furniture", Description = "Mimics are disguesed as perfectly normal pices of furniture in a nearby house."},
            new Encounter {ID = 3,Location="inner", MonsterType = "monster", Name = "Chimera Nest", Description = "A chimera is resting in a tall spire.Aggressive and territorial, it swoops down to rip apart any who wander around its turf."},
            new Encounter {ID = 4,Location="sewer", MonsterType = "monster", Name = "Cleaning Cube", Description = "A gelatinous cube awaits down a narrow corrider in the swers. It stays completely still until a creature enters its space."},
            new Encounter {ID = 5,Location="inner", MonsterType = "monster", Name = "Crimson Countess", Description = "The Crimson Countess hunts above with a retinue of harpies."},
            new Encounter {ID = 6,Location="sewer", MonsterType = "monster", Name = "Dozing Hulk", Description = "A single haze hulk lays sleeping across the narrow road. Squeezing past without waking it may prove difficult, but it cluthces a delerium shard in its hand."},
            new Encounter {ID = 7,Location="sewer-inner", MonsterType = "monster", Name = "Deep Ones", Description = "Aquatic delerium dregs and 1 chuul occupy a sewer junction or are emerging from a sewer exit."},
            new Encounter {ID = 8,Location="sewer-outer-inner", MonsterType = "none", Name = "Double Trouble", Description = "Roll twice, ignoring this result on subsequent rolls. If two groups of monsters of NPCs are encountered, they're fighting each other."},
            new Encounter {ID = 9,Location="sewer", MonsterType = "monster", Name = "Drowned Dead", Description = "A one-hundred-foot long corridor in the sewers is completely flooded. The tunnel has several haze hulks floating in it that appear lifeless unless attacked or until characters are halfway down the tunnel. The undead attempt to hold characters in place until they drown."},
            new Encounter {ID = 10,Location="inner", MonsterType = "monster", Name = "Executioner's Summons", Description = "The characters stumble into Slaughterstone Square"},
            new Encounter {ID = 11,Location="sewer-inner", MonsterType = "monster", Name = "Fallen Heroes", Description = "Several haze wights are all that remains of this former adventuring party. They believe any living humanoids they encounter are mutated monsters."},
            new Encounter {ID = 12,Location="outer", MonsterType = "monster", Name = "Garmyr Hunters", Description = "Several garmyr leading worgs are stalking the strees for fresh meat. They are on keen lookout and watch for any signs of movement. Double the number encountered in the Inner City."},
            new Encounter {ID = 13,Location="inner", MonsterType = "monster", Name = "Garmyr Ravagers", Description = "Several garmyr berserkers with hell hounds are rampagin through the streets, howling loudly and starting fires."},
            new Encounter {ID = 14,Location="outer-inner", MonsterType = "monster", Name = "Ghost Lights", Description = "Will-o-wisps attempt to lure passing characters"},
            new Encounter {ID = 15,Location="sewer-outer", MonsterType = "monster", Name = "Gibbering Flesh", Description = "The walls here are covered in thick fleshy growths, parts of the walls, streets and rubble have grown eyes and mouths that break away and form gibbering mouthers. In the Inner City, is has become a protean abomination."},
            new Encounter {ID = 16,Location="sewer-inner", MonsterType = "monster", Name = "Gloaming Ray", Description = "A cloaker flies through the dark rooftops above looking for prey."},
            new Encounter {ID = 17,Location="sewer-inner", MonsterType = "monster", Name = "Going in Circles!", Description = "The characters lose their position and get lost. They no longer know where they are anymore or what direction they are facing. They must wander the city streets for the next several hours, after which they regain their original position. Check for random encounters as normal each hour. A random encounter could result in circumstances where the characters no longer become lost."},
            new Encounter {ID = 18,Location="inner", MonsterType = "monster", Name = "Harpy Flock", Description = "A pack of harpies flies overhead surveying the ground for anything worth hunting. They perch on rooftops and watch the streets below, trying to lure wandering characters up to the roofs to push them off to their deaths."},
            new Encounter {ID = 19,Location="sewer-outer", MonsterType = "monster", Name = "Hateful Dead", Description = "A lone haze wight marches with haze husks. It commands its minions to attack any living creature they find, and raises any nearby corpses as reinforcements. Add 1d4 additional haze wights when encountered in the Inner City."},
            new Encounter {ID = 20,Location="outer", MonsterType = "monster", Name = "Haze Haunt", Description = "A warp witch moans and wails in the nearby building, scornfully mourning its miserable existence as it tries to remember its past. Add an additional 1d4 warp witches when encountered in the Inner City."},
            new Encounter {ID = 21,Location="outer-inner", MonsterType = "lanterns", Name = "Hooded Lantern Patrol", Description = "Scouts led by an urban ranger are on a recon mission. If the characters are in trouble they step in to help them, but then demand the characters turn over half of whatever plunder they've found in the ruins, citing their authority under the 'law' of Westemar and that 'scavenging' in the ruins is technically prohibited without the assent of the Lord Commander."},
            new Encounter {ID = 22,Location="sewer-inner", MonsterType = "none", Name = "Horribly Lost", Description = "The characters are badly turned around and become hopelessly lost in the ruins. They no longer know where they are anymore or what direction they are facing. The wander the city streets indefinitely, checking for random encounters as normal each hour. They don't regain their bearings unless the circumstances of a random encounter lead them to clues or friendly NPCs who can help them."},
            new Encounter {ID = 23,Location="sewer", MonsterType = "monster", Name = "Living Ruins", Description = "Several inanimate parts of the ruins suddenly spring to life as delerium elementals. Choose whichever type is most appropriate for the area."},
            new Encounter {ID = 24,Location="inner", MonsterType = "monster", Name = "Lord of the Feast", Description = "The Lord of the Feast leads a warpack of garmyr and hell hounds."},
            new Encounter {ID = 25,Location="sewer-outer", MonsterType = "monster", Name = "Lost Ones", Description = "Delerium dregs wander the streets ahead. They sorrowfully mutter nonsensical gibberish, but wail and screech when they encounter humanoids. Add 1d4 haze hulks when encountered in the Inner City."},
            new Encounter {ID = 26,Location="inner", MonsterType = "monster", Name = "Lurking Wraiths", Description = "Arcane Wraiths flutter about seeking erratic magic, and fixate on whichever character is carrying the most delerium or magic items."},
            new Encounter {ID = 27,Location="outer", MonsterType = "monster", Name = "Menacing Manticore", Description = "A manticore circles overhead looking for an easy meal. If it spots the characters, it swoops in to attack the most vulnerable member. It flies off towards the innver city if reduced to less than half its hit points. Manticores in the Inner City may hunt in packs of 2d4."},
            new Encounter {ID = 28,Location="outer", MonsterType = "monster", Name = "Old Alchemist's Shop", Description = "A decrepit alchemist's shop the reeks of a chemical odor stands on a street corner. A pool of spilled chemicals has become an aggressive ochre jelly. In the Inner City 1d4 black puddings are encountered here instead."},
            new Encounter {ID = 29,Location="inner", MonsterType = "monster", Name = "Overgrown Ruin", Description = "Strange alien plants and oddly-shaped vines creep up a crumbling ruin. A shambling mound and hypnotic eldritch blossoms grow in the tangled mass."},
            new Encounter {ID = 30,Location="outer", MonsterType = "monster", Name = "Phase Webs", Description = "Strange webs cover this section of the ruins and fill nearby buildings - some even span the streets themselves. Phase spiders resting int he dark corners come to investigate any disturbance of their webs. The webs are especially thick in regions of the Inner City, where there are 2d6 spider instead."},
            new Encounter {ID = 31,Location="outer-inner", MonsterType = "followers", Name = "Pilgrims of the Falling Fire", Description = "A group of cultists led by a cult fanatic and a berserker are heading towards the crater."},
            new Encounter {ID = 32,Location="outer-inner", MonsterType = "queens", Name = "Queen's Men Looters", Description = "Bandits led by a bandit captain are hoping for easy pickings. The bandits try to hide from the players until they appear wounded or in need of a rest, so canny characters might spot them before this happens."},
            new Encounter {ID = 33,Location="outer-inner", MonsterType = "silver", Name = "Questing Knights", Description = "A Silver Order knight on a warhorse with a retinue of guards are searching for lost relics and holy sites in the ruins."},
            new Encounter {ID = 34,Location="inner", MonsterType = "monster", Name = "Ratling Raiders", Description = "A ratling warlock of the rat god leads a great horder of ratlings."},
            new Encounter {ID = 35,Location="sewer-outer-inner", MonsterType = "none", Name = "Rival Adventurers", Description = "Characters encounter a group of rival adventurers."},
            new Encounter {ID = 36,Location="outer", MonsterType = "none", Name = "Run out of Town", Description = "Characters get turned around badly, and arrive at the nearest edge of town."},
            new Encounter {ID = 37,Location="sewer-inner", MonsterType = "monster", Name = "Sewer Monster", Description = "An otyugh feasting on offal lurks near a sewer access point."},
            new Encounter {ID = 38,Location="sewer-outer", MonsterType = "monster", Name = "Shadows of Drakkenheim", Description = "Shadows slowly follow the characters. They try to remain hidden and follow the party until one of the player characters is more than ten feet away from the others, then the shadows strike in an attempt to overwhelm the straggler. An arcane wraith leads these shadows when encountered in the Inner City."},
            new Encounter {ID = 39,Location="outer", MonsterType = "monster", Name = "Shambling Husks", Description = "Haze hulks stumble and shuffle around the streets. In this unsettling gait, they play out scenes of their former everyday lives."},
            new Encounter {ID = 40,Location="sewer-inner", MonsterType = "monster", Name = "Stalking Vermin", Description = "Ratlings and ratling guttersnipes have set up an ambush. These ralings use bait to lure prey toward a dead-end street or sewer passage where the guttersnipes lurk on high ground to snipe their quarry with ranged attacks."},
            new Encounter {ID = 41,Location="sewer-outer", MonsterType = "monster", Name = "Troll Traveller", Description = "A troll is heading through the ruins to join the trolls at King's Gate. He wears a large pack containing raw contaminated meat, a tankard of rancid ale, 2d10 gold, and a few sets of tools and trinkets. If encountered  near a bridge in the Inner City, there are 3 trolls instead."},
            new Encounter {ID = 42,Location="outer-inner", MonsterType = "none", Name = "Uninvited Guests", Description = "The characters arrive at the nearest city gate."},
            new Encounter {ID = 43,Location="inner", MonsterType = "none", Name = "Wandered into the Garden", Description = "The characters arrive at the nearest edge of Queen's Park Garden."},
            new Encounter {ID = 44,Location="outer", MonsterType = "monster", Name = "Watching Gargoyles", Description = "Wall gargoyles roaming overhead swoop down to attack. If encountered in the Inner City, there are 2d6 instead."},
            new Encounter {ID = 45,Location="sewer-outer", MonsterType = "none", Name = "Wrong Turn", Description = "The characters find themselves back where they started an hour ago. I guess you took a wrong turn somewhere?"},
            new Encounter {ID = 46,Location="inner", MonsterType = "monster", Name = "Gibbering Flesh", Description = "The walls here are covered in thick fleshy growths, parts of the walls, streets and rubble have grown eyes and mouths that break away and form gibbering mouthers. In the Inner City, is has become a protean abomination."},
            new Encounter {ID = 47,Location="inner", MonsterType = "monster", Name = "Hateful Dead", Description = "A lone haze wight marches with haze husks. It commands its minions to attack any living creature they find, and raises any nearby corpses as reinforcements. Add 1d4 additional haze wights when encountered in the Inner City."},
            new Encounter {ID = 48,Location="inner", MonsterType = "monster", Name = "Haze Haunt", Description = "A warp witch moans and wails in the nearby building, scornfully mourning its miserable existence as it tries to remember its past. Add an additional 1d4 warp witches when encountered in the Inner City."},
            new Encounter {ID = 49,Location="inner", MonsterType = "monster", Name = "Lost Ones", Description = "Delerium dregs wander the streets ahead. They sorrowfully mutter nonsensical gibberish, but wail and screech when they encounter humanoids. Add 1d4 haze hulks when encountered in the Inner City."},
            new Encounter {ID = 50,Location="inner", MonsterType = "monster", Name = "Menacing Manticore", Description = "A manticore circles overhead looking for an easy meal. If it spots the characters, it swoops in to attack the most vulnerable member. It flies off towards the innver city if reduced to less than half its hit points. Manticores in the Inner City may hunt in packs of 2d4."},
            new Encounter {ID = 51,Location="inner", MonsterType = "monster", Name = "Old Alchemist's Shop", Description = "A decrepit alchemist's shop the reeks of a chemical odor stands on a street corner. A pool of spilled chemicals has become an aggressive ochre jelly. In the Inner City 1d4 black puddings are encountered here instead."},
            new Encounter {ID = 52,Location="inner", MonsterType = "monster", Name = "Phase Webs", Description = "Strange webs cover this section of the ruins and fill nearby buildings - some even span the streets themselves. Phase spiders resting int he dark corners come to investigate any disturbance of their webs. The webs are especially thick in regions of the Inner City, where there are 2d6 spider instead."},
            new Encounter {ID = 53,Location="inner", MonsterType = "monster", Name = "Shadows of Drakkenheim", Description = "Shadows slowly follow the characters. They try to remain hidden and follow the party until one of the player characters is more than ten feet away from the others, then the shadows strike in an attempt to overwhelm the straggler. An arcane wraith leads these shadows when encountered in the Inner City."},
            new Encounter {ID = 54,Location="inner", MonsterType = "monster", Name = "Troll Traveller", Description = "A troll is heading through the ruins to join the trolls at King's Gate. He wears a large pack containing raw contaminated meat, a tankard of rancid ale, 2d10 gold, and a few sets of tools and trinkets. If encountered  near a bridge in the Inner City, there are 3 trolls instead."},
            new Encounter {ID = 55,Location="inner", MonsterType = "monster", Name = "Watching Gargoyles", Description = "Wall gargoyles roaming overhead swoop down to attack. If encountered in the Inner City, there are 2d6 instead."},
            new Encounter {ID = 56,Location="inner", MonsterType = "monster", Name = "Garmyr Hunters", Description = "Several garmyr leading worgs are stalking the strees for fresh meat. They are on keen lookout and watch for any signs of movement. Double the number encountered in the Inner City."}
        };

        public List<Encounter> GetAllEncounters()
        {
            return Encounters;
        }
        public List<Encounter> GetSewerEncounters()
        {
            List<Encounter> sewerEncounters = new List<Encounter>();
            sewerEncounters = Encounters.FindAll(e => e.Location == "sewer" || e.Location == "sewer-outer" || e.Location == "sewer-inner" || e.Location == "sewer-outer-inner");
            return sewerEncounters;
        }
        public List<Encounter> GetOuterEncounters()
        {
            List<Encounter> outerEncounters = new List<Encounter>();
            outerEncounters = Encounters.FindAll(e => e.Location == "outer" || e.Location == "sewer-outer" || e.Location == "outer-inner" || e.Location == "sewer-outer-inner");
            return outerEncounters;
        }
        public List<Encounter> GetInnerEncounters()
        {
            List<Encounter> innerEncounters = new List<Encounter>();
            innerEncounters = Encounters.FindAll(e => e.Location == "inner" || e.Location == "sewer-inner" || e.Location == "outer-inner" || e.Location == "sewer-outer-inner");
            return innerEncounters;
        }
    }
}
