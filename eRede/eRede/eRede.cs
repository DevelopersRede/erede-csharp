using System;
using eRede.Service;

namespace eRede;

public class eRede
{
    public const string Version = "2.0.0";
    public const string UserAgent = "eRede/" + Version + "(SDK; C#)";

    private readonly Store _store;

    public eRede(Store store)
    {
        _store = store;
    }

    public TransactionResponse Authorize(Transaction transaction)
    {
        return Create(transaction);
    }

    public TransactionResponse Create(Transaction transaction)
    {
        var createTransactionService = new CreateTransactionService(_store, transaction);

        return createTransactionService.Execute();
    }

    public TransactionResponse Cancel(Transaction transaction)
    {
        if (transaction.Tid is null) throw new ArgumentException("O tid não foi informado");

        var cancelTransactionService = new CancelTransactionService(_store, transaction);

        return cancelTransactionService.Execute();
    }

    public TransactionResponse Cancel(Transaction transaction, string tid)
    {
        transaction.Tid = tid;

        return Cancel(transaction);
    }

    public TransactionResponse Capture(Transaction transaction)
    {
        if (transaction.Tid is null) throw new ArgumentException("O tid não foi informado");

        var captureTransactionService = new CaptureTransactionService(_store, transaction);

        return captureTransactionService.Execute();
    }

    public TransactionResponse Capture(Transaction transaction, string tid)
    {
        transaction.Tid = tid;

        return Capture(transaction);
    }

    public TransactionResponse Get(string tid)
    {
        var getTransactionService = new GetTransactionService(_store)
        {
            Tid = tid
        };

        return getTransactionService.Execute();
    }

    public TransactionResponse GetByReference(string reference)
    {
        var getTransactionService = new GetTransactionService(_store)
        {
            Reference = reference
        };

        return getTransactionService.Execute();
    }

    public TransactionResponse GetRefunds(string tid)
    {
        var getTransactionService = new GetTransactionService(_store)
        {
            Tid = tid,
            Refund = true
        };

        return getTransactionService.Execute();
    }

    public TransactionResponse Zero(Transaction transaction)
    {
        transaction.Amount = 0;
        transaction.Capture = true;

        return Create(transaction);
    }
}