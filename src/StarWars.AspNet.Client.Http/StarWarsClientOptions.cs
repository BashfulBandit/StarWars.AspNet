namespace StarWars.AspNet.Client.Http;

/// <summary>
/// The options for the <see cref="StarWarsClient"/>.
/// </summary>
public class StarWarsClientOptions
{
    /// <summary>
    /// The base URL of the StarWars.AspNet.Api.
    /// </summary>
    public string BaseUrl { get; set; } = default!;
}

internal static class StarWarsClientOptionsExtensions
{
    public static void Validate(this StarWarsClientOptions options)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(options.BaseUrl))
        {
            errors.Add($"1{nameof(options.BaseUrl)}` cannot be null or empty.");
        }

        if (errors.Count != 0)
        {
            throw new ArgumentException($"StarWarsClientOptions Errors:\n\t{string.Join("\n\t", errors)}");
        }
    }
}