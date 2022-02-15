using System;

namespace DrakkenheimEncountersBot.ZachStuff.Models
{
    // I don't like inheritance. It screws crap up (a lot).
    // In order to make sure no one else inherits from any of my classes OR records,
    // I always add `sealed`. It's very rare that I choose not to seal my classes.
    // If I don't, I have a very very good reason. I can think of only one use case
    // where I am letting inheritance happen in my current codebases.
    internal sealed record Monster(
        Guid Id,
        MonsterName Name,
        MonsterDescription Description,
        MonsterType Type)
    {
        public static Monster Create(MonsterName name, MonsterDescription description, MonsterType type) =>
            new(Guid.NewGuid(), name, description, type);
    }

    internal sealed record MonsterName(string Value)
    {
        public static MonsterName Create(string value)=> new(value);
    }
    internal sealed record MonsterDescription(string Value)
    {
        public static MonsterDescription Create(string value) => new(value);
    }
    internal sealed record MonsterType(MonsterKind Value)
    {
        public static MonsterType Create(MonsterKind value) => new(value);
    }

    internal enum MonsterKind
    {
        Default,
        Academy,
        Monster,
        Lanterns,
        Followers,
        Queens,
        Silver,
        None,
    }
}
