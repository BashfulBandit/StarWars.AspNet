namespace StarWars.AspNet.Core.Commands;

/// <summary>
/// Interface used for implementing command handlers that process commands
/// of a certain type and return a specific result
/// </summary>
/// <typeparam name="TCommand">The command to handle.</typeparam>
/// <typeparam name="TResult">The result of the command.</typeparam>
public interface ICommandHandler<in TCommand, TResult>
    where TCommand : ICommand<TResult>
    where TResult : CommandResult
{
    /// <summary>
    /// Method responsible for handling the command and returning
    /// the result of the operation.
    /// </summary>
    /// <param name="command">The command to be processed.</param>
    /// <param name="cancellation"></param>
    /// <returns>The resulting <typeparamref name="TResult"/>.</returns>
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellation = default);
}
