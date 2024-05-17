using System.Diagnostics.CodeAnalysis;

namespace StarWars.AspNet.Core.Queries;

/// <summary>
/// Abstract class for returning results from the processing of an <see cref="IQuery{TResult}"/>.
/// </summary>
public abstract class QueryResult
{
    protected QueryResult()
    {
        this.Succeeded = true;
    }

    protected QueryResult(Exception error)
    {
        this.Error = error;
        this.Succeeded = false;
    }

    /// <summary>
    /// Property indicating successful processing of the <see cref="IQuery{TResult}"/>.
    /// </summary>
    [MemberNotNullWhen(false, nameof(Error))]
    public bool Succeeded { get; init; }

    /// <summary>
    /// The <see cref="Exception"/> that occurred during the processing of the <see cref="IQuery{TResult}"/>.
    /// </summary>
    public Exception? Error { get; init; }
}
