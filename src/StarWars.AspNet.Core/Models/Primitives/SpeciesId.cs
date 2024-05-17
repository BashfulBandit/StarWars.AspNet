using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

public readonly struct SpeciesId
    : IEquatable<SpeciesId>
{
    private SpeciesId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    public string Value { get; }

    public static SpeciesId From(string value)
        => new(value);
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
