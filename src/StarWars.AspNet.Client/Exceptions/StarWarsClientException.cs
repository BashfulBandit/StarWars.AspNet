namespace StarWars.AspNet.Client.Exceptions;

public class StarWarsClientException
    : Exception
{
    public StarWarsClientException(string message)
        : base(message) { }

    public StarWarsClientException(string message,
        Exception innerException)
        : base(message, innerException) { }
}
