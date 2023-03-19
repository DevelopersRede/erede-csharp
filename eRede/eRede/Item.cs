namespace eRede;

public class Item
{
    public const int Physical = 1;
    public const int Digital = 2;
    public const int Service = 3;
    public const int Airline = 4;

    public Item(string id, int quantity, int type = Physical)
    {
        Id = id;
        Quantity = quantity;
        Type = type;
    }

    public int Amount { get; set; }
    public string Description { get; set; }
    public int Freight { get; set; }
    public string Id { get; }
    public int Quantity { get; }
    public string ShippingType { get; set; }
    public int Type { get; }
}