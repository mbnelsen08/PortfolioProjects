using DrakkenheimEncountersBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Repos
{
    public class LuckyFindsRepo
    {
        private static List<LuckyFinds> finds = new List<LuckyFinds>
        {
            new LuckyFinds{ID=1,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=2,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=3,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=4,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=5,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=6,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=7,Description="Nothing but broken refuse and ruined scraps of weapons and armour."},
            new LuckyFinds{ID=8,Description="1d4 sets of tools in an abandoned workshop."},
            new LuckyFinds{ID=9,Description="5d6 gold pieces in a coin pruse clutched by a severed hand."},
            new LuckyFinds{ID=10,Description="1d6 points of healing in a hidden cache."},
            new LuckyFinds{ID=11,Description="1d4 uncommon spell scrolls tucked in a scroll case by a wizard's corpse."},
            new LuckyFinds{ID=12,Description="1d4 art objects worth 25 gp each are found in a modest townhouse."},
            new LuckyFinds{ID=13,Description="2d6 delerium chips haphazardly stored in a backpack."},
            new LuckyFinds{ID=14,Description="2d6 x 10 gp in a lockbox in an old merchant's tradehouse."},
            new LuckyFinds{ID=15,Description="1 restorative ointment upon an otherwise empty shelf."},
            new LuckyFinds{ID=16,Description="1d4 delerium fragments carefully placed in glass containers."},
            new LuckyFinds{ID=17,Description="1d4 poitions of greater healing in a forsaken shrine."},
            new LuckyFinds{ID=18,Description="A cumbling estate has a piece of artwork worth 250 gp inside."},
            new LuckyFinds{ID=19,Description="1 rare spell scroll in a pile of books and loose pages fluttering down the street."},
            new LuckyFinds{ID=20,Description="Nothing but broken refuse and ruined scraps of weapons and armour."}
        };

        public List<LuckyFinds> GetLuckFinds()
        {
            return finds;
        }
    }
}
