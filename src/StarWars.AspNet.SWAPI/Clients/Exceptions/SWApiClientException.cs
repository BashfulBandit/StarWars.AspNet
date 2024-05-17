namespace StarWars.AspNet.SWAPI.Clients.Exceptions;

/// <summary>
/// Base exception to represent an unknown error either on the client side
/// or the API side.
/// </summary>
internal class SWAPIClientException
    : Exception
{
    /// <inheritdoc/>
    public SWAPIClientException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public SWAPIClientException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

/// <summary>
/// An exception to represent a HTTP 404 - Not Found response from the API.
/// </summary>
internal class SWAPIClientNotFoundException
    : SWAPIClientException
{
    /// <inheritdoc/>
    public SWAPIClientNotFoundException(string message)
        : base(message)
    { }

    /// <inheritdoc/>
    public SWAPIClientNotFoundException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}
