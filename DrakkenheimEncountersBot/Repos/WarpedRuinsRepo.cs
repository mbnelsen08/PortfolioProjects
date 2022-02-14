using DrakkenheimEncountersBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Repos
{
    public class WarpedRuinsRepo
    {
        private static List<WarpedRuins> ruins = new List<WarpedRuins>
        {
            new WarpedRuins{ID=1, Description="Stonework and timbers have transformed into solid glass."},
            new WarpedRuins{ID=2, Description="Cloaked in eldritch fire, but it's not burning down."},
            new WarpedRuins{ID=3, Description="Blown apart, but frozen in time at the middle of the explosion."},
            new WarpedRuins{ID=4, Description="Flesh, limbs, eyes mouths, and faces are merged into the walls. They babble incohertly."},
            new WarpedRuins{ID=5, Description="The side facing the crater is melted like sticky wax."},
            new WarpedRuins{ID=6, Description="Disembodied screams and whispers resound from within."},
            new WarpedRuins{ID=7, Description="All colour within becomes black and white."},
            new WarpedRuins{ID=8, Description="An illusion of childhood memory briefly appreas in the fron door, then vanishes."},
            new WarpedRuins{ID=9, Description="Looking at the building causes deja vu."},
            new WarpedRuins{ID=10, Description="Scorch marks in the shape of human silhouettes are found on the walls and floors."}
        };

        public List<WarpedRuins> GetWarpedRuins()
        {
            return ruins;
        }
    }
}
