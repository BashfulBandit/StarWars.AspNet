namespace StarWars.AspNet.Core.Queries;

/// <summary>
/// Interface to define a query to fetch data.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface IQuery<TResult>
    where TResult : QueryResult
{ }