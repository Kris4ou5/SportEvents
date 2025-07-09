using System;
using System.Collections.Generic;

namespace SportEvents
{
    // Клас, съдържащ основните функции за работа със спортни събития
    internal class Functions
    {
        // Променлива за проследяване на потребителския баланс
        private static decimal balans;

        // Метод за добавяне на ново събитие
        public static void AddEvent()
        {
            PrintHeader("Добавяне на ново събитие");

            // Въвеждане на име, местоположение, дата, брой билети и цена на събитието
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

            // Създаване на нов обект от тип Events и добавяне в списъка
            Events newEvent = new Events(name, location, date, tickets, price);
            Data.events.Add(newEvent);
            Data.Save(); // Запазване на данните

            Console.WriteLine($"✅ Събитието \"{name}\" е успешно добавено!");
            PrintFooter();
        }

        // Метод за покупка на билети
        public static void BuyTickets()
        {
            PrintHeader("Купуване на билети");

            UI.BuyTickets(Data.events); // Показване на наличните събития

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

            // Изчисляване на крайната цена и потвърждение на покупката
            CalculatePrice(countTic, index);
            Data.Save(); // Запазване на промените
            PrintFooter();
        }

        // Метод за изчисляване на крайната цена и стартиране на процеса по потвърждение
        private static void CalculatePrice(int countTic, int index)
        {
            decimal total = countTic * Data.events[index - 1].Price;
            Console.WriteLine($"💸 Цената за {countTic} билета е {total} лв.");
            ConfirmPurchase(total, countTic, index);
        }

        // Потвърждение на покупката и обновяване на баланса и наличността на билетите
        public static void ConfirmPurchase(decimal totalPrice, int ticketCount, int index)
        {
            Console.WriteLine("➡️ Въведете \"yes\" за потвърждение или \"m\" за връщане в менюто:");
            string input = Console.ReadLine();

            if (input == "yes")
            {
                if (balans >= totalPrice) // Проверка дали има достатъчно баланс
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
                UI.SelectOption(); // Връщане в менюто
            }
            else
            {
                Console.WriteLine("❌ Невалидна команда.");
            }
        }

        // Метод за управление на бюджета
        public static void Budget()
        {
            PrintHeader("Управление на бюджета");
            UI.BudgetUI(); // Показва възможностите за бюджетно управление

            string input;
            while ((input = Console.ReadLine()) != "m")
            {
                if (input == "add") // Добавяне на пари в баланса
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
                else if (input == "balans") // Проверка на текущия баланс
                {
                    Console.WriteLine($"💰 Текущ баланс: {balans} лв.");
                    Console.WriteLine("➡️ Въведете \"m\" за менюто.");
                }
                else
                {
                    Console.WriteLine("❌ Невалидна команда. Използвайте \"add\", \"balans\" или \"m\".");
                }
            }

            UI.SelectOption(); // Връщане в менюто
        }

        // Метод за проверка на наличните билети за конкретно събитие
        public static void ShowAvailability()
        {
            PrintHeader("Проверка на наличност");
            Console.Write("➡️ Въведи име на събитие: ");
            string eventName = Console.ReadLine();

            bool found = false;
            foreach (var e in Data.events) // Търсене на събитието
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

        // Метод за затваряне на програмата
        public static void CloseProgram()
        {
            Console.WriteLine("Затваряне на програмата...");
            Environment.Exit(0);
        }

        // Помощен метод за показване на заглавие
        private static void PrintHeader(string title)
        {
            Console.Clear();
            Console.WriteLine(new string('=', 40));
            Console.WriteLine($"🔷 {title.ToUpper()} 🔷");
            Console.WriteLine(new string('=', 40));
        }

        // Помощен метод за показване на подканващ текст и връщане в менюто
        private static void PrintFooter()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine($"➡️ Натиснете {"m"} за връщане в менюто...");
            Console.ReadLine();
            UI.SelectOption();
        }
    }
}
