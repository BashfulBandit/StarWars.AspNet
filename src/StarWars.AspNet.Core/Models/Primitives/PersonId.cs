using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

public readonly struct PersonId
    : IEquatable<PersonId>
{
    private PersonId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    public string Value { get; }

    public static PersonId From(string value)
        => new(value);
    public static PersonId NewId()
        => new("prs-" + Guid.NewGuid());
    public static readonly PersonId Default
        = new("prs-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(PersonId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(PersonId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is PersonId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(PersonId left, PersonId right)
        => left.Equals(right);
    public static bool operator !=(PersonId left, PersonId right)
        => !left.Equals(right);
}
