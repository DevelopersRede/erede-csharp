using System.Collections.Generic;

namespace eRede
{
    public class TransactionResponse
    {
        public int amount { get; set; }
        public Antifraud antifraud { get; set; }
        public bool antifraudRequired { get; set; }

        public string authorizationCode { get; set; }
        public string cancelId { get; set; }


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


        public string securityCode { get; set; }
        public string softDescriptor { get; set; }
        public string storageCard { get; set; }


        public bool subscription { get; set; }
        public ThreeDSecure threeDSecure { get; set; }

        public List<Url> urls { get; set; }

        public List<Link> links { get; set; }
        public Capture capture { get; set; }
        public Authorization authorization { get; set; }
        public string requestDateTime { get; set; }
        public string tid { get; set; }
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
    }
}