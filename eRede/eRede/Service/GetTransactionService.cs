using RestSharp;

namespace eRede.Service;

internal class GetTransactionService : AbstractTransactionService
{
    public GetTransactionService(Store store, Transaction transaction = null) : base(store, transaction)
    {
    }

    public string Reference { get; init; }
    public bool Refund { get; init; }

    protected override string GetUri()
    {
        var uri = base.GetUri();

        if (Reference != null) return uri + "?reference=" + Reference;

        if (Refund) return uri + "/" + Tid + "/Refunds";

        return uri + "/" + Tid;
    }

    public TransactionResponse Execute()
    {
        var request = new RestRequest { Method = Method.Get };

        return SendRequest(request);
    }
}