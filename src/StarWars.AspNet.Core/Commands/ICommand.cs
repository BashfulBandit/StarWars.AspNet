namespace StarWars.AspNet.Core.Commands;

/// <summary>
/// Interface that provides a way to group related commands
/// based on the expected result type.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface ICommand<TResult>
    where TResult : CommandResult
{ }
