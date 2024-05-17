using StarWars.AspNet.Core.Models.Primitives;

namespace StarWars.AspNet.Core.Models;

public class Person
{
    public PersonId Id { get; set; } = PersonId.Default;

    public string Name { get; set; } = default!;

    public string Height { get; set; } = default!;

    public string Mass { get; set; } = default!;

    public string HairColor { get; set; } = default!;

    public string SkinColor { get; set; } = default!;

    public string EyeColor { get; set; } = default!;

    public string BirthYear { get; set; } = default!;

    public string Gender { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default;

    public DateTime UpdatedAt { get; set; } = default;
}
