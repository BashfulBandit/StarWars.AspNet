using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

public readonly struct FilmId
    : IEquatable<FilmId>
{
    private FilmId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    public string Value { get; }

    public static FilmId From(string value)
        => new(value);
    public static FilmId NewId()
        => new("flm-" + Guid.NewGuid());
    public static readonly FilmId Default
        = new("flm-" + Guid.Empty);

    private void Validate()
    {
        if (this.Value.IsEmpty())
        {
            throw new FormatException($"'{nameof(this.Value)}' cannot be empty.");
        }
    }

    public override string ToString()
        => $"{nameof(FilmId)} {{ {nameof(this.Value)} = {this.Value} }}";

    public bool Equals(FilmId other)
        => this.Value == other.Value;

    public override bool Equals(object? obj)
        => obj is FilmId other
        && this.Equals(other);

    public override int GetHashCode()
        => this.Value.GetHashCode();

    public static bool operator ==(FilmId left, FilmId right)
        => left.Equals(right);
    public static bool operator !=(FilmId left, FilmId right)
        => !left.Equals(right);
}
