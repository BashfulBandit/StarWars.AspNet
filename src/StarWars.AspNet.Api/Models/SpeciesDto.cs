using StarWars.AspNet.Core.Models;

namespace StarWars.AspNet.Api.Models;

internal class SpeciesDto
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

internal static class SpeciesExtensions
{
    public static SpeciesDto ToDto(this Species model)
        => new()
        {
            Id = model.Id.Value,
            Name = model.Name,
            Classification = model.Classification,
            Designation = model.Designation,
            AverageHeight = model.AverageHeight,
            AverageLifespace = model.AverageLifespace,
            EyeColors = model.EyeColors,
            HairColors = model.HairColors,
            SkinColors = model.SkinColors,
            Language = model.Language,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
}
