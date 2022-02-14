using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Models
{
   public class Encounter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MonsterType { get; set; }
        public string Location { get; set; }
    }
}
