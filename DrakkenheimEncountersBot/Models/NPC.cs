using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Models
{
    public class NPC
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatBlock { get; set; }
        public string Faction { get; set; }
    }
}
