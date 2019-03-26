using eRede.Service;

namespace eRede
{
    public class eRede
    {
        public const string VERSION = "1.0.0";
        public const string UserAgent = "eRede/" + VERSION + "(SDK; C#)";

        private readonly Store store;

        public eRede(Store store)
        {
            this.store = store;
        }

        public TransactionResponse authorize(Transaction transaction)
        {
            return create(transaction);
        }

        public TransactionResponse create(Transaction transaction)
        {
            var createTransactionService = new CreateTransactionService(store, transaction);

            return createTransactionService.Execute();
        }

        public TransactionResponse cancel(Transaction transaction)
        {
            var cancelTransactionService = new CancelTransactionService(store, transaction);

            return cancelTransactionService.Execute();
        }

        public TransactionResponse capture(Transaction transaction)
        {
            var captureTransactionService = new CaptureTransactionService(store, transaction);

            return captureTransactionService.Execute();
        }

        public TransactionResponse get(string tid)
        {
            var getTransactionService = new GetTransactionService(store)
            {
                tid = tid
            };

            return getTransactionService.Execute();
        }

        public TransactionResponse getByReference(string reference)
        {
            var getTransactionService = new GetTransactionService(store)
            {
                reference = reference
            };

            return getTransactionService.Execute();
        }

        public TransactionResponse getRefunds(string tid)
        {
            var getTransactionService = new GetTransactionService(store)
            {
                tid = tid,
                refund = true
            };

            return getTransactionService.Execute();
        }

        public TransactionResponse zero(Transaction transaction)
        {
            transaction.amount = 0;
            transaction.capture = true;

            return create(transaction);
        }
    }
}