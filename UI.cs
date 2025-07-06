using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents
{
    internal class UI
    {
        public static void SelectOption()
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("Приложение за управление на спортни събития");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Добавяне на ново спортно събитие");
            Console.WriteLine("2. Продажба на билети за събитие");
            Console.WriteLine("3. Проверка на наличността на билети");
            Console.WriteLine("4. Справка за всички спортни събития");
            Console.WriteLine("m. Menu");
            Console.WriteLine("0. Изход");
            Console.WriteLine("===========================================");
            Console.Write("Изберете опция:");


        }


        public static void ShowAllEvents(List<Events> events) //показва всички събития
        {//a
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
