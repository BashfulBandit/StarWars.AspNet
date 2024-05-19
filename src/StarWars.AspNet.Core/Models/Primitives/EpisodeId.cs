using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

/// <summary>
/// Represents a type-safe identifier for a <see cref="Episode"/>.
/// </summary>
public readonly struct EpisodeId
    : IEquatable<EpisodeId>
{
    private EpisodeId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    /// <summary>
    /// The actual internal value of the <see cref="BillingInformationId"/>.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a <see cref="VehicleId"/> from the specified <see cref="string"/>.
    /// </summary>
    /// <param name="value">The specified value.</param>
    /// <returns>The created <see cref="VehicleId"/>.</returns>
    public static EpisodeId From(string value)
        => new(value);

    /// <summary>
    /// Generate a new <see cref="VehicleId"/>.
    /// </summary>
    /// <returns>The generated <see cref="VehicleId"/>.</returns>
    public static EpisodeId NewId()
        => new("flm-" + Guid.NewGuid());
    public static readonly EpisodeId Default
        = new("flm-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(EpisodeId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(EpisodeId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is EpisodeId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(EpisodeId left, EpisodeId right)
        => left.Equals(right);
    public static bool operator !=(EpisodeId left, EpisodeId right)
        => !left.Equals(right);
}
