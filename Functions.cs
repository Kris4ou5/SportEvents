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
using System.Diagnostics.Contracts;

namespace SportEvents
{
    internal class Functions
    {

        private static decimal balans; //тази променлива е за следене на баланса
        public static void AddEvent()
        {

            Console.Clear();
            Console.WriteLine("========== ДОБАВЯНЕ НА НОВО СЪБИТИЕ ==========");

            Console.Write("➡️ Въведете име на събитието: ");
            string name = Console.ReadLine();

            Console.Write("➡️ Въведете местоположение: ");
            string location = Console.ReadLine();

            Console.Write("➡️ Въведете дата и час (ДД.ММ.ГГГГ ЧЧ:ММ): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            while(isDateValid(date) == false) //докато не се въведе валидна дата не може да се продължи
            {
                Console.WriteLine("Грешна дата опитай отново:");
                date = DateTime.Parse(Console.ReadLine());
                
            }


            Console.Write("➡️ Въведете наличен брой билети: ");
            int tickets = int.Parse(Console.ReadLine());
            while (true)
            {
                if (tickets >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Невалиден брой билети. Моля, въведете цяло положително число или нула.");
                }
            }



            Console.Write("➡️ Въведете цена на билет (в ЛВ): ");
            decimal price = decimal.Parse(Console.ReadLine());
            while (true)
            {
                if (price >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Невалидна цена. Моля, въведете положително число или нула.");
                }
            }

            Events newevent = new Events(name, location, date, tickets, price);

            Data.events.Add(newevent);
            Data.Save();

            Console.WriteLine($"✅ Събитието \"{name}\" е успешно добавено!");
            Console.WriteLine("============================================");
        }




        public static void BuyTickets()
        {
            Console.Clear();
            Console.WriteLine("========== КУПУВАНЕ НА БИЛЕТИ ==========");
            UI.BuyTickets(Data.events); 
            Console.Write("➡️ Изберете номер на събитието: ");
            int index = int.Parse(Console.ReadLine());

            while (index == 0 || index > Data.events.Count) // проверява входа
            {
                Console.Write("❌ Грешен номер опитай пак:");
                index = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.Write("➡️ Изберете брой билети: ");
            int countTic = int.Parse(Console.ReadLine());
            while (countTic == 0 || countTic > Data.events[index - 1].TicketsAvailable) // проверява входа отново
            {
                Console.Write("❌ Грешен брой опитай пак:");
                countTic = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            CalculatePrice(countTic, index);
            Data.Save();

        }

        private static void CalculatePrice(int countTic, int index) // метода изчислява цената и потвърждава покупката 
        {
            decimal res = countTic * Data.events[index - 1].Price;
            Console.WriteLine($"💰 Цената за {countTic} билета е {res}лв.");
            ConfirmPurchase(res, index);
            Data.events[index - 1].TicketsAvailable = Data.events[index - 1].TicketsAvailable - countTic; // изчислява как ще се промени броя на билетите при покупка и го запазва

        }
        public static void ConfirmPurchase(decimal res, int index) // оправих го както ми каза
        {

            Console.WriteLine($"➡️ Въведи {"yes"} за да подвърдиш плащането или {"m"} за да се върнеш в Menu-то");

            string buyticket = Console.ReadLine();
            if (buyticket == "yes" && balans >= res)
            {
                balans = balans - res;
                Console.WriteLine("✅ Успешно извърпихте транзакция");
                Console.WriteLine($"💰 Останалият Ви баланс е {balans}");
                Console.WriteLine($"🎟️ Остават още {Data.events[index - 1].TicketsAvailable} билети, които могат да бъдат закупени.");
            }
            if (buyticket == "yes" && balans <= res)
            {
                Console.WriteLine("❌ Нямате достатъчно баланс за да извършите това плащане. Въведи m за да се върнеш в главното menu:");
            }
            if (buyticket == "m")
            {
                UI.SelectOption();
            }


        }

        public static void Budget()
        {
            string addbalans;
            Console.WriteLine("========== БЮДЖЕТ ==========");
            UI.BudgetUI();
            while ((addbalans = Console.ReadLine()) != "m")
            {
                if (addbalans == "add")
                {

                    while (addbalans == "add")
                    {
                        Console.Write($"➡️ Въведи число за да добавиш в сметката си:");
                        int number = int.Parse(Console.ReadLine());
                        balans = balans + number;

                        Console.WriteLine($"✅ Вие успешно добавихте {number}лв. в сметката си.");
                        Console.WriteLine($"💰 Сега разполагате с {balans}лв.");
                        Console.WriteLine();
                        Console.WriteLine($"➡️ Въведи {"add"} за да добавиш пари в сметката си.");
                        Console.WriteLine($"➡️ Въведи {"m"} за да се върнеш в Menu-то.");
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
                            Console.WriteLine($"❌ Въвели сле грешна команда моля въведете {"add"}  или {"m"}");
                        }
                    }
                    break;
                }
                else if (addbalans == "balans")
                {
                    Console.WriteLine($"💰 Вашия баланс е {balans}лв");
                    Console.WriteLine($"➡️ Въведи {"m"} за да се върнеш в Menu-то.");
                    while (addbalans == "m")
                    {
                        addbalans = Console.ReadLine();
                        if (addbalans == "m")
                        {
                            UI.SelectOption();
                        }
                        else
                        {
                            Console.WriteLine("❌ Въвели сте грешна команда");
                        }
                    }


                }
                else
                {
                    Console.WriteLine($"❌ Въвели сле грешна команда моля въведете {"add"}, {"balans"}  или {"m"}");
                    continue;
                }
            }
            if (addbalans == "m")
            {
                UI.SelectOption();
            }




        }
        public static void ShowAvailability()
        {
            Console.Clear();
            Console.Write("➡️ Въведи събитие:");
            string eventName;
            while ((eventName = Console.ReadLine()) != "m") 
            {

                foreach (var e in Data.events)
                {
                    if (e.Name == eventName)
                    {
                        Console.WriteLine($"🎟️ Броя на билетите за {e.Name} са {e.TicketsAvailable} и цената за един билет е {e.Price}лв.");
                    }
                     
                }
                Console.WriteLine("Грешно име върнете се в менюто като натиснете м или пробвайте пак:");
            }
            
        }

        public static void CloseProgram()
        {
            Console.WriteLine("Затваряне на програмата...");
            Environment.Exit(0); // Спира приложението веднага
        }

        private static bool isDateValid(DateTime date) //Проверява дали датата е настояща
        {
            DateTime realDate = DateTime.Now;
            if (date <= realDate)
            {
                return false;
            }
            else { return true; }
        }
    }
}

