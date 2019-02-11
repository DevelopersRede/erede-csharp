using System.Collections.Generic;

namespace eRede
{
    public class Flight
    {
        public string date { get; set; }
        public string ip { get; set; }
        public string number { get; set; }
        public List<Passenger> Passenger { get; set; }

        public string To { get; set; }

        private void PreparePassenger()
        {
            if (Passenger == null) Passenger = new List<Passenger>();
        }


        public Flight AddPassenger(Passenger passenger)
        {
            PreparePassenger();

            Passenger.Add(passenger);

            return this;
        }

        public List<Passenger>.Enumerator getPassengerEnumerator()
        {
            PreparePassenger();

            return Passenger.GetEnumerator();
        }
    }
}