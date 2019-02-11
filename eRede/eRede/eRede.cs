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

        public Transaction authorize(Transaction transaction)
        {
            return create(transaction);
        }

        public Transaction create(Transaction transaction)
        {
            var createTransactionService = new CreateTransactionService(store, transaction);

            return createTransactionService.Execute();
        }

        public Transaction cancel(Transaction transaction)
        {
            var cancelTransactionService = new CancelTransactionService(store, transaction);

            return cancelTransactionService.Execute();
        }

        public Transaction capture(Transaction transaction)
        {
            var captureTransactionService = new CaptureTransactionService(store, transaction);

            return captureTransactionService.Execute();
        }

        public Transaction get(string tid)
        {
            var getTransactionService = new GetTransactionService(store)
            {
                tid = tid
            };

            return getTransactionService.Execute();
        }

        public Transaction getByReference(string reference)
        {
            var getTransactionService = new GetTransactionService(store)
            {
                reference = reference
            };

            return getTransactionService.Execute();
        }

        public Transaction getRefunds(string tid)
        {
            var getTransactionService = new GetTransactionService(store)
            {
                tid = tid,
                refund = true
            };

            return getTransactionService.Execute();
        }

        public Transaction zero(Transaction transaction)
        {
            var amount = transaction.amount;
            var capture = transaction.capture;

            transaction.amount = 0;
            transaction.capture = true;
            transaction = create(transaction);
            transaction.amount = amount;
            transaction.capture = capture;

            return transaction;
        }
    }
}