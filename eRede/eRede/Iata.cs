using System.Collections.Generic;

namespace eRede
{
    public class Iata
    {
        public string code { get; set; }
        public string departureTax { get; set; }
        public List<Flight> flight { get; set; }

        private void PrepareFlight()
        {
            if (flight == null) flight = new List<Flight>();
        }

        public Iata AddFlight(Flight flight)
        {
            PrepareFlight();

            this.flight.Add(flight);

            return this;
        }
    }
}