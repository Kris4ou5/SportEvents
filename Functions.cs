using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents
{
    internal class Functions
    {
        public static void BuyTicket()
        {
            UI.ShowAllEvents(Data.events);
        }
    }
}
