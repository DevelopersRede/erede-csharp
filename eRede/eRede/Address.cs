namespace eRede;

public class Address
{
    public const int Billing = 1;
    public const int Shipping = 2;
    public const int Both = 3;

    public const int Apartment = 1;
    public const int Houst = 2;
    public const int Commercial = 3;
    public const int Other = 4;

    private string address { get; set; }
    private string AddresseeName { get; set; }
    private string City { get; set; }
    private string Number { get; set; }
    private string State { get; set; }
    private int Type { get; set; }
    private string ZipCode { get; set; }
}