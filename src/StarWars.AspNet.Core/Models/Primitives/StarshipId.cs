using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

/// <summary>
/// Represents a type-safe identifier for a <see cref="Starship"/>.
/// </summary>
public readonly struct StarshipId
    : IEquatable<StarshipId>
{
    private StarshipId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    /// <summary>
    /// The actual internal value of the <see cref="StarshipId"/>.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a <see cref="StarshipId"/> from the specified <see cref="string"/>.
    /// </summary>
    /// <param name="value">The specified value.</param>
    /// <returns>The created <see cref="StarshipId"/>.</returns>
    public static StarshipId From(string value)
        => new(value);

    /// <summary>
    /// Generate a new <see cref="StarshipId"/>.
    /// </summary>
    /// <returns>The generated <see cref="StarshipId"/>.</returns>
    public static StarshipId NewId()
        => new("ssh-" + Guid.NewGuid());
    public static readonly StarshipId Default
        = new("ssh-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(StarshipId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(StarshipId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is StarshipId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(StarshipId left, StarshipId right)
        => left.Equals(right);
    public static bool operator !=(StarshipId left, StarshipId right)
        => !left.Equals(right);
}
