// Remember to remove unused usings to help clean up the code base
// We don't want to load these namespaces into memory if we don't need them.
// Use CTRL + R -> CTRL + G (by default) to automatically clean up your using statements.
using System;
using System.Collections.Generic;
using System.Text;

namespace DrakkenheimEncountersBot.Models
{
    public class CommonLocation
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
