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
        // Уникален идентификатор за събитието (генерира се автоматично при създаване)
        public string eventID { get; set; }

        // Име на събитието
        public string Name { get; set; }

        // Локация (място) на провеждане на събитието
        public string Location { get; set; }

        // Дата и час на събитието
        public DateTime Date { get; set; }

        // Наличен брой билети за събитието
        public int TicketsAvailable { get; set; }

        // Цена на един билет за събитието
        public decimal Price { get; set; }

       
        public Events(string name, string location, DateTime date, int ticketsAvailable, decimal price)
        {
            // Генериране на уникален идентификатор за събитието
            eventID = Guid.NewGuid().ToString();

            // Задаване на стойности за останалите свойства
            Name = name;
            Location = location;
            Date = date;
            TicketsAvailable = ticketsAvailable;
            Price = price;
        }
    }
}
