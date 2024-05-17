using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

public readonly struct VehicleId
    : IEquatable<VehicleId>
{
    private VehicleId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    public string Value { get; }

    public static VehicleId From(string value)
        => new(value);
    public static VehicleId NewId()
        => new("spc-" + Guid.NewGuid());
    public static readonly VehicleId Default
        = new("spc-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(VehicleId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(VehicleId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is VehicleId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(VehicleId left, VehicleId right)
        => left.Equals(right);
    public static bool operator !=(VehicleId left, VehicleId right)
        => !left.Equals(right);
}
