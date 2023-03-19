using RestSharp;

namespace eRede.Service;

internal class CaptureTransactionService : AbstractTransactionService
{
    public CaptureTransactionService(Store store, Transaction transaction) : base(store, transaction)
    {
        Tid = transaction.Tid;
    }

    protected override string GetUri()
    {
        return base.GetUri() + "/" + Tid;
    }

    public TransactionResponse Execute()
    {
        return base.Execute(Method.Put);
    }
}