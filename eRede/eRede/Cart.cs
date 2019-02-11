using System.Collections.Generic;

namespace eRede
{
    public class Cart
    {
        public Address billing { get; set; }
        public Customer customer { get; set; }
        public Environment environment { get; set; }
        public Iata iata { get; set; }
        public List<Item> items { get; set; }
        public List<Address> shipping { get; set; }

        private void PrepareItems()
        {
            if (items == null) items = new List<Item>();
        }

        public Address address(int type = Address.BOTH)
        {
            var address = new Address();

            if ((type & Address.BILLING) == Address.BILLING) billing = address;

            if ((type & Address.SHIPPING) == Address.SHIPPING) shipping = new List<Address> {address};

            return address;
        }

        public List<Item>.Enumerator getItemEnumerator()
        {
            PrepareItems();

            return items.GetEnumerator();
        }
    }
}