using System.Collections.Generic;

namespace eRede;

public class Flight
{
    public string Date { get; set; }
    public string Ip { get; set; }
    public string Number { get; set; }
    public List<Passenger> Passenger { get; set; }

    public string To { get; set; }

    private void PreparePassenger()
    {
        Passenger ??= new List<Passenger>();
    }


    public Flight AddPassenger(Passenger passenger)
    {
        PreparePassenger();

        Passenger.Add(passenger);

        return this;
    }

    public List<Passenger>.Enumerator GetPassengerEnumerator()
    {
        PreparePassenger();

        return Passenger.GetEnumerator();
    }
}