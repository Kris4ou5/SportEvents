using System;
using System.Collections.Generic;

namespace SportEvents
{
   
    internal class UI
    {
     
        // Основно меню с избор на опции от потребителя.
        public static void SelectOption()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        ⚽ Приложение за управление на събития 🏆       ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════╣");
            Console.ResetColor();

            // Изброяване на опциите
            Console.WriteLine("  1️  ➤ Добавяне на ново спортно събитие");
            Console.WriteLine("  2️  ➤ Продажба на билети за събитие");
            Console.WriteLine("  3️  ➤ Проверка на наличността на билети");
            Console.WriteLine("  4️  ➤ Справка за всички спортни събития");
            Console.WriteLine("  5️  ➤ 💰 Бюджет");
            Console.WriteLine("  m️  ➤ 📜 Меню");
            Console.WriteLine("  0️  ➤ ❌ Изход");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("👉 Изберете опция: "); // Подканване към потребителя
        }

   
        // Показва пълен списък с всички налични спортни събития.
        // Ако няма събития - извежда съобщение.
        public static void ShowAllEvents(List<Events> events)
        {
            Console.Clear();
            if (events.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("❗ Няма налични спортни събития.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("📋 Списък с всички спортни събития:");
            Console.ResetColor();

            // Обхождане и показване на информация за всяко събитие
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"🔹 Събитие #{i + 1}");
                ShowEventInfo(events[i]);
                Console.WriteLine("──────────────────────────────────────────────");
            }

            Console.WriteLine("Въведи м за да се върнеш в менюто:");
        }

        // Показва списък с наличните събития за закупуване на билети.
        public static void BuyTickets(List<Events> events)
        {
            Console.Clear();
            if (events.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("❗ Няма налични събития за покупка на билети.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("🎟️ Избери събитие, за което искаш да купиш билети:");
            Console.ResetColor();

            // Показване само на имената на събитията с пореден номер
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {events[i].Name}");
            }

            Console.Write("\n👉 Въведи номер на събитието: "); // Потребителят въвежда избрания номер
        }

        // Показва пълната информация за дадено събитие.
        public static void ShowEventInfo(Events eventi)
        {
            // Извеждане на всички ключови свойства на обекта Events
            Console.WriteLine($"   🆔 ID: {eventi.eventID}");
            Console.WriteLine($"   📛 Име: {eventi.Name}");
            Console.WriteLine($"   📍 Местоположение: {eventi.Location}");
            Console.WriteLine($"   📅 Дата: {eventi.Date:dd.MM.yyyy}");
            Console.WriteLine($"   🎫 Билети: {eventi.TicketsAvailable}");
            Console.WriteLine($"   💸 Цена: {eventi.Price} лв.");
        }

        // Показва опциите за управление на бюджета (добавяне на пари и проверка на баланс).
        public static void BudgetUI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("💰 Управление на бюджета:");
            Console.ResetColor();

            // Подсказване какви команди може да използва потребителят
            Console.WriteLine("  ➕ Въведи 'add' за да добавиш пари в сметката си.");
            Console.WriteLine("  📊 Въведи 'balans' за да видиш с колко пари разполагаш.");
            Console.WriteLine("  🔙 Въведи 'm' за да се върнеш в менюто.");
            Console.Write("\n👉 Избери опция: ");
        }
    }
}
