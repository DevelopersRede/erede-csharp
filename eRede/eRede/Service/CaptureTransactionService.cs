using RestSharp;

namespace eRede.Service
{
    internal class CaptureTransactionService : AbstractTransactionService
    {
        public CaptureTransactionService(Store store, Transaction transaction) : base(store, transaction)
        {
            this.tid = transaction?.tid;
        }

        public TransactionResponse Execute()
        {
            return base.Execute(Method.PUT);
        }
    }
}
