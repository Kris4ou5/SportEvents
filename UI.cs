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
            Console.Clear();
            foreach (var e in events)
            {
                Console.WriteLine(e);
            }
        }

    }
}
