using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace SportEvents
{
    internal class Functions
    {
       

        public static void AddEvent()
        {
            
            Console.WriteLine("--- Добавяне на ново събитие ---");



            // Console.WriteLine($"Автоматично генерирано ID на събитието: {eventId}"); 


            Console.Write("Въведете име на събитието: ");
             string name = Console.ReadLine();


            Console.Write("Въведете местоположение: ");
             string location = Console.ReadLine();



            Console.Write("Въведете дата и час (ДД.ММ.ГГГГ ЧЧ:ММ): ");
            DateTime date = DateTime.Parse(Console.ReadLine());




            Console.Write("Въведете наличен брой билети: ");
          int tickets = int.Parse(Console.ReadLine());
            while (true)
            {
                if (tickets >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Невалиден брой билети. Моля, въведете цяло положително число или нула.");
                }
            }



            Console.Write("Въведете цена на билет (в ЛВ): ");
            decimal price = decimal.Parse(Console.ReadLine());
            while (true)
            {
                if (price >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Невалидна цена. Моля, въведете положително число или нула.");
                }
            }

            Events newevent = new Events(name, location, date, tickets, price);

            Data.events.Add(newevent);
            Data.Save();

        }
           
            
      

        public static void  BuyTickets()
        {
            UI.ShowAllEvents(Data.events);
            Console.Write($"Избери събитие от 1 до {Data.events.Count}");
            int index = int.Parse(Console.ReadLine()) ;

            while (index  == 0 || index > Data.events.Count + 1)
            {
                Console.Write("Грешен номер опитай пак:");
                index = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine("Избери брой билети:");
            int countTic = int.Parse(Console.ReadLine());
            while (countTic == 0 || countTic > Data.events[index-1].TicketsAvailable)
            {
                Console.Write("Грешен брой опитай пак:");
                countTic = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            CalculatePrice(countTic, index);
            Data.Save();

        }

        private static void  CalculatePrice(int countTic, int index)
        {
            decimal res = countTic * Data.events[index].Price;
            Console.WriteLine($"цената за {countTic} билета е {res}лв.");
            Data.events[index - 1].TicketsAvailable = Data.events[index - 1].TicketsAvailable - countTic;

        }

        public static void ShowAvailability()
        {
            Console.Clear();
            Console.Write("Въведи събитие:");
            string eventName = Console.ReadLine();
            foreach(var e in Data.events)
            {
                if(e.Name == eventName)
                {
                    Console.WriteLine($"Броя на билетите за {e.Name} са {e.TicketsAvailable} и цената за един билет е {e.Price}лв.");
                }
            }
        }
    }
}


       