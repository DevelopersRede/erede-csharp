using System;
using eRede.Service.Error;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace eRede.Service;

internal abstract class AbstractTransactionService
{
    private readonly Store _store;
    private readonly Transaction _transaction;

    internal AbstractTransactionService(Store store, Transaction transaction)
    {
        _store = store;
        _transaction = transaction;
    }

    public string Tid { get; init; }

    protected virtual string GetUri()
    {
        return _store.Environment.Endpoint("transactions");
    }

    public TransactionResponse Execute(Method method = Method.Post)
    {
        var request = new RestRequest { Method = method, RequestFormat = DataFormat.Json };

        request.AddJsonBody(_transaction);

        return SendRequest(request);
    }

    protected TransactionResponse SendRequest(RestRequest request)
    {
        var client = new RestClient(GetUri())
        {
            Authenticator = new HttpBasicAuthenticator(_store.Filliation, _store.Token)
        };

        request.AddHeader("Transaction-Response", "brand-return-opened");
        request.AddHeader("User-Agent", eRede.UserAgent);

        var response = client.Execute(request);

        if (response is null) throw new NullReferenceException("Response is null");
        if (response.Content is null) throw new NullReferenceException("Response content is null");

        var status = (int)response.StatusCode;

        switch (status)
        {
            case >= 200 and < 300:
                return JsonConvert.DeserializeObject<TransactionResponse>(response.Content);
            case >= 300 and < 400:
                throw new RedeException("A requisição foi redirecionada");
        }

        var error = JsonConvert.DeserializeObject<RedeError>(response.Content);
        var exception = new RedeException
        {
            Error = error
        };

        throw exception;
    }
}