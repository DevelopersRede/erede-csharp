using RestSharp;

namespace eRede.Service
{
    internal class GetTransactionService : AbstractTransactionService
    {
        public GetTransactionService(Store store, Transaction transaction = null) : base(store, transaction)
        {
        }

        public string reference { get; set; }
        public bool refund { get; set; }

        protected string getUri()
        {
            var uri = getUri();

            if (reference != null) return uri + "?reference=" + reference;

            if (refund) return uri + "/" + tid + "/refunds";

            return uri;
        }

        public Transaction Execute()
        {
            var request = new RestRequest {Method = Method.GET};

            return sendRequest(request);
        }
    }
}