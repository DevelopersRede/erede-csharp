using RestSharp;

namespace eRede.Service
{
    internal class CaptureTransactionService : AbstractTransactionService
    {
        public CaptureTransactionService(Store store, Transaction transaction) : base(store, transaction)
        {
        }

        public Transaction Execute()
        {
            return Execute(Method.PUT);
        }
    }
}