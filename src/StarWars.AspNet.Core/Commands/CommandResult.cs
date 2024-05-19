using System.Diagnostics.CodeAnalysis;

namespace StarWars.AspNet.Core.Commands;

/// <summary>
/// Abstract class for returning results from the processing of an <see cref="ICommand{TResult}"/>.
/// </summary>
public abstract class CommandResult
{
    protected CommandResult()
    {
        this.Succeeded = true;
    }

    protected CommandResult(Exception error)
    {
        this.Error = error;
        this.Succeeded = false;
    }

    /// <summary>
    /// Property indicating successful processing of the <see cref="ICommand{TResult}"/>.
    /// </summary>
    [MemberNotNullWhen(false, nameof(Error))]
    public bool Succeeded { get; }

    /// <summary>
    /// The <see cref="Exception"/> that occurred during the processing of the <see cref="ICommand{TResult}"/>.
    /// </summary>
    public Exception? Error { get; }
}
