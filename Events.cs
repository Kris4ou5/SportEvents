using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents
{
    internal class Events
    {
        public string  eventID {  get; set; }
        public string Name {  get; set; }
        public string Location { get; set; }

        public DateTime Date { get; set; }
         
        public int TicketsAvailable { get; set; }

        public decimal  Price { get; set; }

        public Events(string name,string location, DateTime date, int ticketsAvailable, decimal price)
        {
            eventID = Guid.NewGuid().ToString();
            Name = name;
            Location = location;
            Date = date;
            TicketsAvailable = ticketsAvailable;
            Price = price;
        }
    }
}
