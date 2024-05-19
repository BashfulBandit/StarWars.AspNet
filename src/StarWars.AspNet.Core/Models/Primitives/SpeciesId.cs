using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

/// <summary>
/// Represents a type-safe identifier for a <see cref="Species"/>.
/// </summary>
public readonly struct SpeciesId
    : IEquatable<SpeciesId>
{
    private SpeciesId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    /// <summary>
    /// The actual internal value of the <see cref="BillingInformationId"/>.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a <see cref="SpeciesId"/> from the specified <see cref="string"/>.
    /// </summary>
    /// <param name="value">The specified value.</param>
    /// <returns>The created <see cref="SpeciesId"/>.</returns>
    public static SpeciesId From(string value)
        => new(value);

    /// <summary>
    /// Generate a new <see cref="SpeciesId"/>.
    /// </summary>
    /// <returns>The generated <see cref="SpeciesId"/>.</returns>
    public static SpeciesId NewId()
        => new("spc-" + Guid.NewGuid());
    public static readonly SpeciesId Default
        = new("spc-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(SpeciesId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(SpeciesId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is SpeciesId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(SpeciesId left, SpeciesId right)
        => left.Equals(right);
    public static bool operator !=(SpeciesId left, SpeciesId right)
        => !left.Equals(right);
}
