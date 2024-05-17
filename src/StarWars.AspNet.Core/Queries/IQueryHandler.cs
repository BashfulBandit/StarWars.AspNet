namespace StarWars.AspNet.Core.Queries;

/// <summary>
/// Interface used to define the handling of a <see cref="IQuery{TResult}"/>.
/// </summary>
/// <typeparam name="TQuery">The query used to retrieve data.</typeparam>
/// <typeparam name="TResult">The result of the query.</typeparam>
public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : QueryResult
{
    /// <summary>
    /// Method responsible for processing a <see cref="IQuery{TResult}"/>.
    /// </summary>
    /// <param name="query">The query to be processed.</param>
    /// <param name="cancellation">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation of processing the <see cref="IQuery{TResult}"/>.</returns>
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellation = default);
}