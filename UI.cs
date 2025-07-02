using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents
{
    internal class UI
    {
        public static void ShowAllEvents(List<Events> events) //показва всички събития
        {
            int i = 0;
            while (i < events.Count)
            {
                var ev = events[i];
                Console.WriteLine($"ID: {ev.eventID}");
                Console.WriteLine($"Име: {ev.Name}");
                Console.WriteLine($"Местоположение: {ev.Location}");
                Console.WriteLine($"Дата: {ev.Date:dd.MM.yyyy}");
                Console.WriteLine($"Билети: {ev.TicketsAvailable}");
                Console.WriteLine($"Цена: {ev.Price} лв.");

                i++;
            }

        }



    }
}
