using System.Collections.Generic;
using System.IO;

namespace eRede;

public class Transaction
{
    public const string Credit = "credit";
    public const string Debit = "debit";

    public const int OrigineRede = 1;
    public const int OriginVisaCheckout = 4;
    public const int OriginMasterpass = 6;

    private bool _capture;

    public int Amount { get; set; }
    public Authorization Authorization { get; set; }
    public string AuthorizationCode { get; set; }
    public string CancelId { get; set; }

    public bool Capture
    {
        get => _capture;
        set
        {
            if (!value && Kind.Equals(Debit))
                throw new InvalidDataException("Debit transactions will always be captured");

            _capture = value;
        }
    }

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
    public string RequestDateTime { get; set; }
    public string ReturnCode { get; set; }
    public string ReturnMessage { get; set; }
    public string SecurityCode { get; set; }
    public string SoftDescriptor { get; set; }
    public string StorageCard { get; set; }

    public bool Subscription { get; set; }
    public ThreeDSecure ThreeDSecure { get; set; }
    public string Tid { get; set; }
    public List<Url> Urls { get; set; }
    public Additional Additional { get; set; }

    public SubMerchant SubMerchant { get; set; }
    public string PaymentFacilitatorID { get; set; }

    private void PrepareRefunds()
    {
        Refunds ??= new List<Refund>();
    }

    private void PrepareUrls()
    {
        Urls ??= new List<Url>();
    }

    public Transaction AddUrl(string url, string kind = Url.Callback)
    {
        PrepareUrls();
        Urls.Add(new Url { Kind = kind, url = url });

        return this;
    }

    public Transaction IataTransaction(string code, string departureTax)
    {
        Iata = new Iata { Code = code, DepartureTax = departureTax };

        return this;
    }

    public Transaction CreditCard(
        string cardNumber,
        string securityCode,
        string expirationMonth,
        string expirationYear,
        string cardHolderName,
        bool capture = true
    )
    {
        Card(cardNumber, securityCode, expirationMonth, expirationYear, cardHolderName, Credit);

        Capture = capture;

        return this;
    }

    public Transaction DebitCard(
        string cardNumber,
        string securityCode,
        string expirationMonth,
        string expirationYear,
        string cardHolderName
    )
    {
        Card(cardNumber, securityCode, expirationMonth, expirationYear, cardHolderName, Debit);

        Capture = true;
        ThreeDSecure = new ThreeDSecure
        {
            Embedded = true,
            OnFailure = ThreeDSecure.DeclineOnFailure
        };

        return this;
    }


    private void Card(string cardNumber, string securityCode, string expirationMonth,
        string expirationYear,
        string cardHolderName, string kind)
    {
        CardNumber = cardNumber;
        SecurityCode = securityCode;
        ExpirationMonth = expirationMonth;
        ExpirationYear = expirationYear;
        CardHolderName = cardHolderName;
        Kind = kind;
    }

    public void Mcc(string softDescriptor, string paymentFacilitatorID, SubMerchant subMerchant)
    {
        SoftDescriptor = softDescriptor;
        PaymentFacilitatorID = paymentFacilitatorID;
        SubMerchant = subMerchant;
    }
}