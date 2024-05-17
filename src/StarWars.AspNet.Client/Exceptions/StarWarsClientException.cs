namespace StarWars.AspNet.Client.Exceptions;

public class StarWarsClientException
    : Exception
{
    public StarWarsClientException(string message)
        : base(message)
    { }

    public StarWarsClientException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}

public class StarWarsClientNotFoundException
    : StarWarsClientException
{
    public StarWarsClientNotFoundException(string message)
        : base(message)
    { }

    public StarWarsClientNotFoundException(string message,
        Exception innerException)
        : base(message, innerException)
    { }
}
