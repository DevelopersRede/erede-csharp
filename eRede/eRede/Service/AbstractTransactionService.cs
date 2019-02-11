using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace eRede.Service
{
    internal abstract class AbstractTransactionService
    {
        private readonly Store store;
        private readonly Transaction transaction;

        internal AbstractTransactionService(Store store, Transaction transaction)
        {
            this.store = store;
            this.transaction = transaction;
        }

        public string tid { get; set; }

        protected string getUri()
        {
            return store.environment.Endpoint("transactions");
        }

        public Transaction Execute(Method method = Method.POST)
        {
            var json = JsonConvert.SerializeObject(transaction, Formatting.None,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });

            var request = new RestRequest {Method = method, RequestFormat = DataFormat.Json};

            request.AddJsonBody(transaction);

            return sendRequest(request);
        }

        protected Transaction sendRequest(RestRequest request)
        {
            var client = new RestClient(getUri())
            {
                UserAgent = eRede.UserAgent,
                Authenticator = new HttpBasicAuthenticator(store.filliation, store.token)
            };

            var response = client.Execute(request);
            var status = (int) response.StatusCode;

            if (status < 200 || status >= 400) throw response.ErrorException;

            return JsonConvert.DeserializeObject<Transaction>(response.Content);
        }
    }
}