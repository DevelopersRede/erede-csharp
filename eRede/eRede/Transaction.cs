using System.Collections.Generic;
using System.IO;

namespace eRede
{
    public class Transaction
    {
        public const string CREDIT = "credit";
        public const string DEBIT = "debit";

        public const int ORIGIN_EREDE = 1;
        public const int ORIGIN_VISA_CHECKOUT = 4;
        public const int ORIGIN_MASTERPASS = 6;

        public int amount { get; set; }
        public Antifraud antifraud { get; set; }
        public bool antifraudRequired { get; set; }
        public Authorization authorization { get; set; }
        public string authorizationCode { get; set; }
        public string cancelId { get; set; }

        public bool capture { get; set; }
        public string cardBin { get; set; }
        public string cardHolderName { get; set; }
        public string cardNumber { get; set; }
        public Cart cart { get; set; }
        public string dateTime { get; set; }
        public int distributorAffiliation { get; set; }
        public string expirationMonth { get; set; }
        public string expirationYear { get; set; }
        public Iata iata { get; set; }
        public int installments { get; set; }
        public string kind { get; set; }
        public string last4 { get; set; }
        public string nsu { get; set; }
        public string origin { get; set; }
        public string reference { get; set; }
        public string refundDateTime { get; set; }
        public string refundId { get; set; }
        public List<Refund> refunds { get; set; }
        public string requestDateTime { get; set; }
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public string securityCode { get; set; }
        public string softDescriptor { get; set; }
        public string storageCard { get; set; }

        public bool subscription { get; set; }
        public ThreeDSecure threeDSecure { get; set; }
        public string tid { get; set; }
        public List<Url> urls { get; set; }
        public Additional additional { get; set; }
        
        private void PrepareRefunds()
        {
            if (refunds == null) refunds = new List<Refund>();
        }

        private void PrepareUrls()
        {
            if (urls == null) urls = new List<Url>();
        }

        public Transaction AddUrl(string url, string kind = Url.Callback)
        {
            PrepareUrls();
            urls.Add(new Url {kind = kind, url = url});

            return this;
        }

        public Transaction Iata(string code, string departureTax)
        {
            iata = new Iata {code = code, departureTax = departureTax};

            return this;
        }

        public Transaction Capture(bool capture = true)
        {
            if (!capture && kind.Equals(DEBIT))
                throw new InvalidDataException("Debit transactions will always be captured");

            this.capture = capture;

            return this;
        }

        public Transaction CreditCard(string cardNumber, string securityCode, string expirationMonth,
            string expirationYear,
            string cardHolderName, bool capture = true)
        {
            SetCard(cardNumber, securityCode, expirationMonth, expirationYear, cardHolderName, CREDIT);

            this.capture = capture;

            return this;
        }

        public Transaction DebitCard(string cardNumber, string securityCode, string expirationMonth,
            string expirationYear,
            string cardHolderName)
        {
            SetCard(cardNumber, securityCode, expirationMonth, expirationYear, cardHolderName, DEBIT);

            capture = true;
            threeDSecure = new ThreeDSecure
            {
                embedded = true,
                onFailure = ThreeDSecure.DECLINE_ON_FAILURE
            };

            return this;
        }


        private void SetCard(string cardNumber, string securityCode, string expirationMonth,
            string expirationYear,
            string cardHolderName, string kind)
        {
            this.cardNumber = cardNumber;
            this.securityCode = securityCode;
            this.expirationMonth = expirationMonth;
            this.expirationYear = expirationYear;
            this.cardHolderName = cardHolderName;
            this.kind = kind;
        }
    }
}