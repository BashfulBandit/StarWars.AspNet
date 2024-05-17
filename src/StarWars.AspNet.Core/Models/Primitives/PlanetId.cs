using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

public readonly struct PlanetId
    : IEquatable<PlanetId>
{
    private PlanetId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    public string Value { get; }

    public static PlanetId From(string value)
        => new(value);
    public static PlanetId NewId()
        => new("plt-" + Guid.NewGuid());
    public static readonly PlanetId Default
        = new("plt-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(PlanetId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(PlanetId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is PlanetId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(PlanetId left, PlanetId right)
        => left.Equals(right);
    public static bool operator !=(PlanetId left, PlanetId right)
        => !left.Equals(right);
}
