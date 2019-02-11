namespace eRede.Service
{
    internal class CancelTransactionService : AbstractTransactionService
    {
        public CancelTransactionService(Store store, Transaction transaction) : base(store, transaction)
        {
        }

        protected string getUri()
        {
            return getUri() + "/" + tid + "/refunds";
        }
    }
}