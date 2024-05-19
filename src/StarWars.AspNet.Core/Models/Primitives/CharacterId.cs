using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

/// <summary>
/// Represents a type-safe identifier for a <see cref="Character"/>.
/// </summary>
public readonly struct CharacterId
    : IEquatable<CharacterId>
{
    private CharacterId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    /// <summary>
    /// The actual internal value of the <see cref="BillingInformationId"/>.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a <see cref="CharacterId"/> from the specified <see cref="string"/>.
    /// </summary>
    /// <param name="value">The specified value.</param>
    /// <returns>The created <see cref="CharacterId"/>.</returns>
    public static CharacterId From(string value)
        => new(value);

    /// <summary>
    /// Generate a new <see cref="CharacterId"/>.
    /// </summary>
    /// <returns>The generated <see cref="CharacterId"/>.</returns>
    public static CharacterId NewId()
        => new("prs-" + Guid.NewGuid());
    public static readonly CharacterId Default
        = new("prs-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(CharacterId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(CharacterId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is CharacterId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(CharacterId left, CharacterId right)
        => left.Equals(right);
    public static bool operator !=(CharacterId left, CharacterId right)
        => !left.Equals(right);
}
