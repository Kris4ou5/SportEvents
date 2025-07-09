using System;
using System.Collections.Generic;

namespace SportEvents
{
    internal class Functions
    {
        private static decimal balans; // Проследяване на баланса

        public static void AddEvent()
        {
            PrintHeader("Добавяне на ново събитие");

            Console.Write("➡️ Въведете име на събитието: ");
            string name = Console.ReadLine();

            Console.Write("➡️ Въведете местоположение: ");
            string location = Console.ReadLine();

            Console.Write("➡️ Въведете дата и час (ДД.ММ.ГГГГ ЧЧ:ММ): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("❌ Грешен формат. Моля, опитайте отново: ");
            }

            Console.Write("➡️ Въведете наличен брой билети: ");
            int tickets;
            while (!int.TryParse(Console.ReadLine(), out tickets) || tickets < 0)
            {
                Console.Write("❌ Моля, въведете цяло положително число: ");
            }

            Console.Write("➡️ Въведете цена на билет (в ЛВ): ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.Write("❌ Моля, въведете положително число: ");
            }

            Events newEvent = new Events(name, location, date, tickets, price);
            Data.events.Add(newEvent);
            Data.Save();

            Console.WriteLine($"✅ Събитието \"{name}\" е успешно добавено!");
            PrintFooter();
        }

        public static void BuyTickets()
        {
            PrintHeader("Купуване на билети");

            UI.BuyTickets(Data.events);
            Console.Write("➡️ Изберете номер на събитието: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > Data.events.Count)
            {
                Console.Write("❌ Грешен номер. Опитайте пак: ");
            }

            Console.Write("➡️ Изберете брой билети: ");
            int countTic;
            while (!int.TryParse(Console.ReadLine(), out countTic) || countTic <= 0 || countTic > Data.events[index - 1].TicketsAvailable)
            {
                Console.Write("❌ Грешен брой. Опитайте пак: ");
            }

            CalculatePrice(countTic, index);
            Data.Save();
            PrintFooter();
        }

        private static void CalculatePrice(int countTic, int index)
        {
            decimal total = countTic * Data.events[index - 1].Price;
            Console.WriteLine($"💸 Цената за {countTic} билета е {total} лв.");
            ConfirmPurchase(total, countTic, index);
        }

        public static void ConfirmPurchase(decimal totalPrice, int ticketCount, int index)
        {
            Console.WriteLine("➡️ Въведете \"yes\" за потвърждение или \"m\" за връщане в менюто:");
            string input = Console.ReadLine();

            if (input == "yes")
            {
                if (balans >= totalPrice)
                {
                    balans -= totalPrice;
                    Data.events[index - 1].TicketsAvailable -= ticketCount;
                    Console.WriteLine("✅ Успешно извършихте плащане!");
                    Console.WriteLine($"💰 Останал баланс: {balans} лв.");
                    Console.WriteLine($"🎟️ Остават {Data.events[index - 1].TicketsAvailable} билета за това събитие.");
                }
                else
                {
                    Console.WriteLine("❌ Недостатъчен баланс!");
                }
            }
            else if (input == "m")
            {
                UI.SelectOption();
            }
            else
            {
                Console.WriteLine("❌ Невалидна команда.");
            }
        }

        public static void Budget()
        {
            PrintHeader("Управление на бюджета");
            UI.BudgetUI();

            string input;
            while ((input = Console.ReadLine()) != "m")
            {
                if (input == "add")
                {
                    Console.Write("➡️ Въведи сума за добавяне: ");
                    if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
                    {
                        balans += amount;
                        Console.WriteLine($"✅ Добавихте {amount} лв. Текущ баланс: {balans} лв.");
                    }
                    else
                    {
                        Console.WriteLine("❌ Невалидна сума.");
                    }
                    Console.WriteLine("➡️ Въведете \"add\" за добавяне на още средства или \"m\" за менюто.");
                }
                else if (input == "balans")
                {
                    Console.WriteLine($"💰 Текущ баланс: {balans} лв.");
                    Console.WriteLine("➡️ Въведете \"m\" за менюто.");
                }
                else
                {
                    Console.WriteLine("❌ Невалидна команда. Използвайте \"add\", \"balans\" или \"m\".");
                }
            }

            UI.SelectOption();
        }

        public static void ShowAvailability()
        {
            PrintHeader("Проверка на наличност");
            Console.Write("➡️ Въведи име на събитие: ");
            string eventName = Console.ReadLine();

            bool found = false;
            foreach (var e in Data.events)
            {
                if (e.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"🎟️ Брой билети: {e.TicketsAvailable}, Цена: {e.Price} лв.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("❌ Не е намерено такова събитие.");
            }

            PrintFooter();
        }

        public static void CloseProgram()
        {
            Console.WriteLine("Затваряне на програмата...");
            Environment.Exit(0);
        }

        // ✅ Помощни методи за по-ясен интерфейс
        private static void PrintHeader(string title)
        {
            Console.Clear();
            Console.WriteLine(new string('=', 40));
            Console.WriteLine($"🔷 {title.ToUpper()} 🔷");
            Console.WriteLine(new string('=', 40));
        }

        private static void PrintFooter()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine($"➡️ Натиснете {"m"} за връщане в менюто...");
            Console.ReadLine();
            UI.SelectOption();
        }
    }
}
