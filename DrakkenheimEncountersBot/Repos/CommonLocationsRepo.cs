using DrakkenheimEncountersBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Repos
{
    public class CommonLocationsRepo
    {
        private static List<CommonLocation> locations = new List<CommonLocation>
        {
            new CommonLocation{ID=1, Description="Breakaway meteors demolished this area, leaving only broken cobblestones and toppled ruins riddled with small craters."},
            new CommonLocation{ID=2, Description="A makeshift encampment. There's a canvas tent, sleeping bags, and a few improvised barricades or defences. Embers still burn in the campfire."},
            new CommonLocation{ID=3, Description="A deserted alleyway filled with trash, access point to the sewers."},
            new CommonLocation{ID=4, Description="A devastated street filled with broken wagons, abandoned vendor's stalls, and bones."},
            new CommonLocation{ID=5, Description="An open plaza or park around a small monument, fountain, or well."},
            new CommonLocation{ID=6, Description="A courtyard leading up to a civic building, shrine, chapel, or estate."},
            new CommonLocation{ID=7, Description="A cluster of ramshackle taverns."},
            new CommonLocation{ID=8, Description="Seedy tenement buildings and rundown shacks."},
            new CommonLocation{ID=9, Description="Several workshops surrounded by warehouses."},
            new CommonLocation{ID=10, Description="Rows of dilapidated and heavily damaged townhouses."}
        };

        public List<CommonLocation> GetAllLocations()
        {
            return locations;
        }
    }
}
