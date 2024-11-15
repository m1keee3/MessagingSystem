namespace Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record Success() : OperationResult;

    public sealed record MessageAlreadyReadFault() : OperationResult;

    public sealed record LowPriorityLvlFault() : OperationResult;
}