using StarWars.AspNet.Core.Extensions;

namespace StarWars.AspNet.Core.Models.Primitives;

public readonly struct EpisodeId
    : IEquatable<EpisodeId>
{
    private EpisodeId(string value)
    {
        this.Value = value;
        this.Validate();
    }

    public string Value { get; }

    public static EpisodeId From(string value)
        => new(value);
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
