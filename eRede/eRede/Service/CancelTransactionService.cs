namespace eRede.Service;

internal class CancelTransactionService : AbstractTransactionService
{
    public CancelTransactionService(Store store, Transaction transaction) : base(store, transaction)
    {
        Tid = transaction.Tid;
    }

    protected override string GetUri()
    {
        return base.GetUri() + "/" + Tid + "/refunds";
    }
}