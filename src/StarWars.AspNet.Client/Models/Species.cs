namespace StarWars.AspNet.Client.Models;

public class Species
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Classification { get; set; } = default!;

    public string Designation { get; set; } = default!;

    public string AverageHeight { get; set; } = default!;

    public string AverageLifespace { get; set; } = default!;

    public IEnumerable<string> EyeColors { get; set; } = default!;

    public IEnumerable<string> HairColors { get; set; } = default!;

    public IEnumerable<string> SkinColors { get; set; } = default!;

    public string Language { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default;

    public DateTime UpdatedAt { get; set; } = default;
}
