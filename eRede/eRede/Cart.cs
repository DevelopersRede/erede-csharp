using System.Collections.Generic;

namespace eRede;

public class Cart
{
    public Address Billing { get; set; }
    public Customer Customer { get; set; }
    public Environment Environment { get; set; }
    public Iata Iata { get; set; }
    public List<Item> Items { get; set; }
    public List<Address> Addresses { get; set; }

    private void PrepareItems()
    {
        Items ??= new List<Item>();
    }

    public Address Address(int type = global::eRede.Address.Both)
    {
        var address = new Address();

        if ((type & global::eRede.Address.Billing) == global::eRede.Address.Billing) Billing = address;

        if ((type & global::eRede.Address.Shipping) == global::eRede.Address.Shipping)
            Addresses = new List<Address> { address };

        return address;
    }

    public List<Item>.Enumerator GetItemEnumerator()
    {
        PrepareItems();

        return Items.GetEnumerator();
    }
}