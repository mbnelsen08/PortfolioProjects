using DrakkenheimEncountersBot.ZachStuff.Models;
using System.Collections.Generic;

namespace DrakkenheimEncountersBot.ZachStuff.Repositories
{
    internal sealed class EncounterRepository
    {
        private readonly IReadOnlyCollection<Encounter> _encounters = new List<Encounter>
        {
            Encounter.Create(
                EncounterName.Create("Honey grab the flyswatter."),
                EncounterDescription.Create("Damn there are a lot of bugs in here."),
                MonsterRepository.Spiders,
                EncounterLocation.Create(LocationKind.Inner)),

            Encounter.Create(
                EncounterName.Create("Who cut the che... RATS!!"),
                EncounterDescription.Create("You were holding the map upside down, doofus."),
                MonsterRepository.CheeseLovingCritters,
                EncounterLocation.Create(LocationKind.SewerOuterInner)),

            Encounter.Create(
                EncounterName.Create("Korban... my man... "),
                EncounterDescription.Create("Lets win a vacation"),
                MonsterRepository.FifthElementers,
                EncounterLocation.Create(LocationKind.Outer))
        };
    }
}
