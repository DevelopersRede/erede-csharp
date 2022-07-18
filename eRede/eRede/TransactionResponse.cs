using System.Collections.Generic;

namespace eRede;

public class TransactionResponse
{
    public int Amount { get; set; }

    public string AuthorizationCode { get; set; }
    public string CancelId { get; set; }
    public Brand Brand { get; set; }
    public string BrandTid { get; set; }

    public string CardBin { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public Cart Cart { get; set; }
    public string DateTime { get; set; }
    public int DistributorAffiliation { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public Iata Iata { get; set; }
    public int Installments { get; set; }
    public string Kind { get; set; }
    public string Last4 { get; set; }
    public string Nsu { get; set; }
    public string Origin { get; set; }
    public string Reference { get; set; }
    public string RefundDateTime { get; set; }
    public string RefundId { get; set; }
    public List<Refund> Refunds { get; set; }


    public string SecurityCode { get; set; }
    public string SoftDescriptor { get; set; }
    public string StorageCard { get; set; }


    public bool Subscription { get; set; }
    public ThreeDSecure ThreeDSecure { get; set; }

    public List<Url> Urls { get; set; }

    public List<Link> Links { get; set; }
    public Capture Capture { get; set; }
    public Authorization Authorization { get; set; }
    public string RequestDateTime { get; set; }
    public string Tid { get; set; }
    public string ReturnCode { get; set; }
    public string ReturnMessage { get; set; }
}