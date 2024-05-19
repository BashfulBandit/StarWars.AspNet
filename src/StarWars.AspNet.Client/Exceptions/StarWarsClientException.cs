namespace StarWars.AspNet.Client.Exceptions;

/// <summary>
/// An exception representing a unknown error from the StarWars.Api.
/// </summary>
public class StarWarsClientException
    : Exception
{
    /// <inheritdoc/>
    public StarWarsClientException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public StarWarsClientException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// An exception representing a HTTP 400 - Not Found response from the StarWars.Api.
/// </summary>
public class StarWarsClientNotFoundException
    : StarWarsClientException
{
    /// <inheritdoc/>
    public StarWarsClientNotFoundException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public StarWarsClientNotFoundException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}
