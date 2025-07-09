using System;
using System.Collections.Generic;

namespace SportEvents
{
    internal class UI
    {
        public static void SelectOption()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        ⚽ Приложение за управление на събития 🏆       ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.WriteLine("  1️⃣  ➤ Добавяне на ново спортно събитие");
            Console.WriteLine("  2️⃣  ➤ Продажба на билети за събитие");
            Console.WriteLine("  3️⃣  ➤ Проверка на наличността на билети");
            Console.WriteLine("  4️⃣  ➤ Справка за всички спортни събития");
            Console.WriteLine("  5️⃣  ➤ 💰 Бюджет");
            Console.WriteLine("  m️⃣  ➤ 📜 Меню");
            Console.WriteLine("  0️⃣  ➤ ❌ Изход");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("👉 Изберете опция: ");
        }

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

            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"🔹 Събитие #{i + 1}");
                ShowEventInfo(events[i]);
                Console.WriteLine("──────────────────────────────────────────────");
            }
        }

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

            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {events[i].Name}");
            }

            Console.Write("\n👉 Въведи номер на събитието: ");
           
        }

        public static void ShowEventInfo(Events eventi)
        {
            Console.WriteLine($"   🆔 ID: {eventi.eventID}");
            Console.WriteLine($"   📛 Име: {eventi.Name}");
            Console.WriteLine($"   📍 Местоположение: {eventi.Location}");
            Console.WriteLine($"   📅 Дата: {eventi.Date:dd.MM.yyyy}");
            Console.WriteLine($"   🎫 Билети: {eventi.TicketsAvailable}");
            Console.WriteLine($"   💸 Цена: {eventi.Price} лв.");
        }

        public static void BudgetUI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("💰 Управление на бюджета:");
            Console.ResetColor();

            Console.WriteLine("  ➕ Въведи 'add' за да добавиш пари в сметката си.");
            Console.WriteLine("  📊 Въведи 'balans' за да видиш с колко пари разполагаш.");
            Console.WriteLine("  🔙 Въведи 'm' за да се върнеш в менюто.");
            Console.Write("\n👉 Избери опция: ");
        }
    }
}
