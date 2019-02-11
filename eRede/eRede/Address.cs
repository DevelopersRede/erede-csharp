namespace eRede
{
    public class Address
    {
        public const int BILLING = 1;
        public const int SHIPPING = 2;
        public const int BOTH = 3;

        public const int APARTMENT = 1;
        public const int HOUST = 2;
        public const int COMMERCIAL = 3;
        public const int OTHER = 4;

        private string address { get; set; }
        private string addresseeName { get; set; }
        private string city { get; set; }
        private string number { get; set; }
        private string state { get; set; }
        private int type { get; set; }
        private string zipCode { get; set; }
    }
}