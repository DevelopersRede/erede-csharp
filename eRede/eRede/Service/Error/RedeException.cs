using System;

namespace eRede.Service.Error;

public class RedeException : Exception
{
    public RedeException()
    {
    }

    public RedeException(string message) : base(message)
    {
    }

    public RedeError Error { get; init; }
}