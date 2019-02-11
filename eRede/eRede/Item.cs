namespace eRede
{
    public class Item
    {
        public const int PHYSICAL = 1;
        public const int DIGITAL = 2;
        public const int SERVICE = 3;
        public const int AIRLINE = 4;

        public Item(string id, int quantity, int type = PHYSICAL)
        {
            this.id = id;
            this.quantity = quantity;
            this.type = type;
        }

        public int amount { get; set; }
        public string description { get; set; }
        public int freight { get; set; }
        public string id { get; set; }
        public int quantity { get; set; }
        public string shippingType { get; set; }
        public int type { get; set; }
    }
}