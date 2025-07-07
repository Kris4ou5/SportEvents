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

        private static decimal balans; //тази променлива е за следене на баланса
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
            UI.BuyTickets(Data.events);
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
            ConfirmPurchase(res,balans); 
            Data.events[index - 1].TicketsAvailable = Data.events[index - 1].TicketsAvailable - countTic;
            
        }
        public static void ConfirmPurchase(decimal res,decimal balans) //оправих го както ми каза
        {
            
            Console.WriteLine($"Въведи{"Потвърди"} за да подвърдиш плащането или {"m"} за да се върнеш в Menu-то" );
     
            string buyticket = Console.ReadLine();
            if ( buyticket == "Потвърди" && balans >= res ) 
            {
                Console.WriteLine("Успешно извърпихте транзакция");
                Console.WriteLine($"Останалият Ви баланс е {balans - res}");
            }
            if ( buyticket == "Потвърди" && balans <= res )
            {
                Console.WriteLine("Нямате достатъчно баланс за да извършите това плащане");
            }
            if( buyticket == "m")
            {
                UI.SelectOption();
            }

            
         }

        public static void Budget()
        {
            string addbalans;
            
            Console.WriteLine($"Въведи {"add"} за да добавиш пари в сметката си.");
            Console.WriteLine($"Въведи {"balans"} за да видеш с колко пари разполагаш.");
            Console.WriteLine($"Въведи {"m"} за да се върнеш в Menu-то.");
            addbalans = Console.ReadLine();
            if (addbalans == "add")
            {
                
                while (addbalans == "add")
                {
                    Console.Write($"Въведи число за да добавиш в сметката си:");
                    int number = int.Parse(Console.ReadLine());
                    balans = balans + number;

                    Console.WriteLine($"Вие успешно добавихте {number}лв. в сметката си.");
                    Console.WriteLine($"Сега разполагата с {balans}лв.");
                    Console.WriteLine($"Въведи {"add"} за да добавиш пари в сметката си.");
                    Console.WriteLine($"Въведи {"m"} за да се върнеш в Menu-то.");
                    addbalans = Console.ReadLine();
                    if (addbalans == "add")
                    {
                        continue;
                    }
                    else if (addbalans == "m")
                    {
                        UI.SelectOption();
                        break;

                    }
                    else
                    {
                        Console.WriteLine($"Въвели сле грешна команда моля въведете {"add"}  или {"m"}");
                    }
                }

            }
            else if (addbalans == "balans")
            {
                Console.WriteLine($"Вашия баланс е {balans}лв");  
                Console.WriteLine($"Въведи {"m"} за да се върнеш в Menu-то.");
               while (addbalans == "m")
                {
                    addbalans = Console.ReadLine();
                    if (addbalans == "m")
                    {
                        UI.SelectOption();
                    }
                    else
                    {
                        Console.WriteLine("Въвели сте грешна команда");
                    }
                }
                
               
            }
            else if(addbalans == "m")
            {
                UI.SelectOption();
            }
            else
            {
                Console.WriteLine($"Въвели сле грешна команда моля въведете {"add"}, {"balans"}  или {"m"}");
            }



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


       