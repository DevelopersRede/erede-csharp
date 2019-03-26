namespace eRede.Service
{
    internal class CancelTransactionService : AbstractTransactionService
    {
        public CancelTransactionService(Store store, Transaction transaction) : base(store, transaction)
        {
        }

        protected override string getUri()
        {
            return base.getUri() + "/" + tid + "/refunds";
        }
    }
}