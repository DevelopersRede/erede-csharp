using System.Collections.Generic;

namespace eRede;

public class Iata
{
    public string Code { get; set; }
    public string DepartureTax { get; set; }
    public List<Flight> Flight { get; set; }

    private void PrepareFlight()
    {
        Flight ??= new List<Flight>();
    }

    public Iata AddFlight(Flight flight)
    {
        PrepareFlight();

        Flight.Add(flight);

        return this;
    }
}