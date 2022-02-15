using System;
using System.Collections.Generic;

namespace DrakkenheimEncountersBot.ZachStuff.Models
{
    // Records have a bunch of automatic stuff that is built in, like Cloning and an implementation for IEquatable.
    // Not to mention the syntax is much more concise than traditional classes, make them a great choice for Domain modeling.
    // Guids look like: dbc83b3d-1a1b-46fd-93da-785bbb5f7121
    // Guids are guaranteed to be unique. Can be easier to work with than having to do dumb incrementing IDs.
    // All we care about is that they are unique and can match, Guids work great.
    internal sealed record Encounter(
        Guid Id,
        EncounterName Name,
        EncounterDescription Description,
        IReadOnlyCollection<Monster> Monsters,
        EncounterLocation Location)
    {
        public static Encounter Create(
            EncounterName name, 
            EncounterDescription description,
            IReadOnlyCollection<Monster> monsters,
            EncounterLocation location) => 
            new(Guid.NewGuid(), name, description, monsters, location);
    }

    // An EncounterName is fundamentally different than an EncounterDescription.
    // Despite both being "strings" under the hood, we want to make sure we don't mix them up.
    // This is where Domain Driven Design comes in. We wrap the inner primitive (string) inside
    // of another type. This way we can be explicit in our method signatures about what parameters 
    // we want passed to us.
    //
    // The drawback is having to do `.Value` everywhere and it is more verbose to get the types
    // inside of there wrappers.
    //
    // On small projects it may not be worth it, but on larger projects it will save your butt
    // more times than you think.
    internal sealed record EncounterName(string Value)
    {
        // You can just do new EncounterName("MyEncounter"), but I prefer static create methods.
        // New is glue and looks ugly.
        // var myEncounterName = EncounterName.Create("My Encounter");
        // This looks and feels cleaner ( to me ).
        public static EncounterName Create(string value) => new(value);
    }
    internal sealed record EncounterDescription(string Value)
    {
                                                        // This function already knows we're gonna return a
                                                        // EncounterDescription. We don't need to explicitly
                                                        // say so (not in C# 9 and C# 10.
                                                        // It will be able to figure it out for us.
                                                        // Hover over `new(value)` and see what Intellisense says!
        public static EncounterDescription Create(string value) => new(value);
    }
    internal sealed record EncounterLocation(LocationKind Value)
    {
        public static EncounterLocation Create(LocationKind value) => new(value);
    }

    internal enum LocationKind
    {
        Default,
        Inner,
        Outer,
        OuterInner,
        Sewer,
        SewerInner,
        SewerOuterInner,
        SewerOuter,
    }
}
