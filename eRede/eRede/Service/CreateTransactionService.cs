namespace eRede.Service;

internal class CreateTransactionService : AbstractTransactionService
{
    public CreateTransactionService(Store store, Transaction transaction) : base(store, transaction)
    {
    }
}