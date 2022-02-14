using DrakkenheimEncountersBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Repos
{
    public class NpcRepo
    {
        private static List<NPC> NPCs = new List<NPC> 
        {
            new NPC{ID=1, Name="Leon The Swine", Description="Leader of the Pin & Clubs. A scrawny middle aged man with a scar over his left eye and a mohawk. He carries a saber and a dagger, and chains hang from his leather vest and black trousers.", Faction="Queen's Men", StatBlock="Bandit Captain"},
            new NPC{ID=2, Name="Rose Carver", Description="Leader of the Rose & Thorns. A striking red-haired woman with piercing eyes and studded leather armour. She has a belt filled with daggers, and steel-tipped boots with several spikes on the toes.", Faction="Queen's Men", StatBlock="Veteran"},
            new NPC{ID=3, Name="Christian Lament", Description="Leader of The Wounded Hearts. A tall blonde elven spy. He has blue eyes and wears a flowing cape and black noble's clothing with gold filigree. He carries a rapier and daggers.", Faction="Queen's Men", StatBlock="Spy"},
            new NPC{ID=4, Name="Baskerville", Description="Leader of The Howlin' Dogs. A large grey-skinned half-orc man with muscles bulging our of his vest. He has several piercings and carries two axes. His body is covered in varous scars and wounds.", Faction="Queen's Men", StatBlock="Gladiator"},
            new NPC{ID=5, Name="Veronica Venom", Description="Leader of The Catacomb Cobras. A human assassin who wears a black hood and dark leather armour. She has a bandolier of poison vials and 4 daggers fastened in her belt.", Faction="Queen's Men", StatBlock="Assassin"},
            new NPC{ID=6, Name="Knight-Lieutenant Cassandra Wyatt", Description="A human woman who leads the aerial units.", Faction="Knights of the Silver Order", StatBlock="Cavalier"},
            new NPC{ID=7, Name="Ser Virgil Underwood", Description="A human knight", Faction="Knights of the Silver Order", StatBlock="Knight"},
            new NPC{ID=8, Name="Austin Edwards", Description="A young knight, eager to leap into battle for his cause.", Faction="Knights of the Silver Order", StatBlock="Knight"},
            new NPC{ID=9, Name="Adam", Description="A stoic and thoughtful paladin with a cautious attitude towards Drakkenheim.", Faction="Knights of the Silver Order", StatBlock="Knight"},
            new NPC{ID=10, Name="Claudia", Description="A determined knight with the qualities of great leadership.", Faction="Knights of the Silver Order", StatBlock="Knight"},
            new NPC{ID=11, Name="Delilah", Description="An aspiring Flamekeeper with a fiery attitude and strong will.", Faction="Knights of the Silver Order", StatBlock="Priest"},
            new NPC{ID=12, Name="Quinn", Description="A new recruit optimistic and eager to impress her team.", Faction="Knights of the Silver Order", StatBlock="Guard"},
            new NPC{ID=13, Name="Elijah", Description="A paladin who takes great pleasure in defeating monsters in combat.", Faction="Knights of the Silver Order", StatBlock="Knight"},
            new NPC{ID=14, Name="Buddy Knox", Description="A guitar strumming bard who sings the deeds of the Knights of the Silver Order", Faction="Knights of the Silver Order", StatBlock="Bard"},
            new NPC{ID=15, Name="Noah", Description="A aging man with a big white beard who takes things in stride.", Faction="Knights of the Silver Order", StatBlock="Veteran"},
            new NPC{ID=16, Name="Ruth", Description="A Flamekeeper who takes her job as a healer very seriously.", Faction="Knights of the Silver Order", StatBlock="Priest"},
            new NPC{ID=17, Name="Zacharias", Description="An arrogant knight who fears no monster or abomination in Drakkenheim.", Faction="Knights of the Silver Order", StatBlock="Kngiht"},
            new NPC{ID=18, Name="Chud Hopkins", Description="A halfing scout who occasionally helps with patrols or watches, or works as a chef in the barracks kitchen.", Faction="The Hooded Lanterns", StatBlock="Scout"},
            new NPC{ID=19, Name="Sten LivingSton", Description="A human scout often positioned out in front of the City Watch Barracks as one of the head watchment.", Faction="The Hooded Lanterns", StatBlock="Scout"},
            new NPC{ID=20, Name="Raine Highlash", Description="A human urban ranger who runs patrols around the Outer City.", Faction="The Hooded Lanterns", StatBlock="Urban Ranger"},
            new NPC{ID=21, Name="Jakob Slovak", Description="A human urban ranger of Shepard's Gate", Faction="The Hooded Lanterns", StatBlock="Urban Ranger"},
            new NPC{ID=22, Name="Luther Hess", Description="A rotund guard, lazy and unwilling to do above the bare minimum.", Faction="The Hooded Lanterns", StatBlock="Guard"},
            new NPC{ID=23, Name="Tresa Metterling", Description="An optimistic guard with a hopful outlook for Drakkenheim.", Faction="The Hooded Lanterns", StatBlock="Guard"},
            new NPC{ID=24, Name="'Old' Symon Vasilisk", Description="An agin human guard who rarely leaves the barracks and is on his way to retirement.", Faction="The Hooded Lanterns", StatBlock="Guard"},
            new NPC{ID=25, Name="Rolf Wagner", Description="A young man of noble birth, sent to the city on his father's behalf to fight for the Lanterns.", Faction="The Hooded Lanterns", StatBlock="Noble"},
            new NPC{ID=26, Name="Greta Braun", Description="A young guard with aspirations of climbing the ranks of the Lanterns.", Faction="The Hooded Lanterns", StatBlock="Guard"},
            new NPC{ID=27, Name="Alena Kruger", Description="A calm veteran who prides herself in her observational skills.", Faction="The Hooded Lanterns", StatBlock="Veteran"},
            new NPC{ID=28, Name="Alycia Martell", Description="Afraid of almost everything in Drakkenheim but determined to fight for her beliefs.", Faction="The Hooded Lanterns", StatBlock="Guard"},
            new NPC{ID=29, Name="Brother Abraham Schaefer", Description="A faithful old preacher naive to the horrors of Drakkenheim.", Faction="The Followers of the Falling Fire", StatBlock="Priest"},
            new NPC{ID=30, Name="George Hopper", Description="A courageous fighter who dutifully protexts other pilgrims.", Faction="The Followers of the Falling Fire", StatBlock="Knight"},
            new NPC{ID=31, Name="Anita Winters", Description="A strong and sturdy warrior who had visions of the metoer.", Faction="The Followers of the Falling Fire", StatBlock="Knight"},
            new NPC{ID=32, Name="Dekota Jones", Description="A young explorer who questions everything.", Faction="The Followers of the Falling Fire", StatBlock="Cultist"},
            new NPC{ID=33, Name="Cosmos", Description="An optimistic tiefling who is obesses with planar travel.", Faction="The Followers of the Falling Fire", StatBlock="Cultist"},
            new NPC{ID=34, Name="Rufus Apollo", Description="An old dwarven cleric who studies astological sign and patterns.", Faction="The Followers of the Falling Fire", StatBlock="Priest"},
            new NPC{ID=35, Name="Ingrid and Mara Stumer", Description="Sister who followed dreams and visions to the city.", Faction="The Followers of the Falling Fire", StatBlock="Cultist"},
            new NPC{ID=36, Name="Silvie Roseshot", Description="A former Flamekeeper inspired by the Testmanent of the Falling Fire.", Faction="The Followers of the Falling Fire", StatBlock="Priest"},
            new NPC{ID=37, Name="Lucy Wainright", Description="A creative and intelligent woman with a child who came to the city for salvation.", Faction="The Followers of the Falling Fire", StatBlock="Cultist"},
            new NPC{ID=38, Name="Jared Walsh", Description="A young paladin who believes he will fulfil his oath by taking the Sacrament.", Faction="The Followers of the Falling Fire", StatBlock="Knight"},
            new NPC{ID=39, Name="Rufus Stonewall", Description="A grumpy old professor who is looking forward to retiring.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=40, Name="Nimble Quill", Description="An eager new graduate hoping to prove themselves.", Faction="The Amethyst Academy", StatBlock="Academy Apprentice(pg. 29)"},
            new NPC{ID=41, Name="Cogsworth B. Copperpot", Description="An addled old diviner confused about his own predictions.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=42, Name="Murdok the Caller", Description="A know-it-all conjurer with a knack for hacing the perfect spell prepared.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=43, Name="Corvus Greysky", Description="A grim necromancer with a mordbid sense of humor.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=44, Name="Elvira Evermore", Description="A stern abjurer who takes magic use very seriously.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=45, Name="Luna Mumph", Description="A young gnome illusionist who seems lost in ther own world.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=46, Name="Harmon Munk", Description="An elf transmuter who is always misplacing his alchemical reagents.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=47, Name="Neptune Lee", Description="A charismatic enchanger who likes to boast about his accomplishments.", Faction="The Amethyst Academy", StatBlock="Mage"},
            new NPC{ID=48, Name="August 'Gus' Elderfire", Description="An experienced evoker who ever does things by the book.", Faction="The Amethyst Academy", StatBlock="Mage"}
        };

        public List<NPC> GetAllNpcs()
        {
            return NPCs;
        }

        public List<NPC> GetFactionNpcs(string factionName)
        {
            List<NPC> factionNpcs = NPCs.FindAll(n => n.Faction == factionName);
            return factionNpcs;
        }
    }
}
