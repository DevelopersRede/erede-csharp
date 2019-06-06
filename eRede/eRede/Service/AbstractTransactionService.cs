using System;
using eRede.Service.Error;
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

        protected virtual string getUri()
        {
            return store.environment.Endpoint("transactions");
        }

        public TransactionResponse Execute(Method method = Method.POST)
        {
            var request = new RestRequest {Method = method, RequestFormat = DataFormat.Json};

            request.AddJsonBody(transaction);

            return sendRequest(request);
        }

        protected TransactionResponse sendRequest(RestRequest request)
        {
            var client = new RestClient(getUri())
            {
                UserAgent = eRede.UserAgent,
                Authenticator = new HttpBasicAuthenticator(store.filliation, store.token)
            };

            var response = client.Execute(request);
            var status = (int) response.StatusCode;

            if (status < 200 || status >= 400)
            {
                RedeError error = JsonConvert.DeserializeObject<RedeError>(response.Content);
                RedeException exception = new RedeException
                {
                    error = error
                };

                throw exception;
            }

            return JsonConvert.DeserializeObject<TransactionResponse>(response.Content);
        }
    }
}