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
            Console.Clear();
            int i = 0;
            while (i < events.Count)
            {
                ShowEventInfo(events[i]);
                i++;
                Console.WriteLine("");
            }

        }

        public static void BuyTickets(List<Events> events)
        {
            //Гриша измисли как да свържеш евентите тоест искам да селектва всеки евент и да изписва името му примерно I е равно на 1 и изписва първия евент :)
            Console.WriteLine("Моля избери събитие:");
            int i = 1;
            while (i <= events.Count) 
            {
                
                Console.WriteLine($"{i}." + events[i].Name);
                i++;
            }
            
        }

        public static void ShowEventInfo(Events eventi) //упростявам малко кода като просто го отделям в метод      
        {
            
            Console.WriteLine($"ID: {eventi.eventID}");
            Console.WriteLine($"Име: {eventi.Name}");
            Console.WriteLine($"Местоположение: {eventi.Location}");
            Console.WriteLine($"Дата: {eventi.Date:dd.MM.yyyy}");
            Console.WriteLine($"Билети: {eventi.TicketsAvailable}");
            Console.WriteLine($"Цена: {eventi.Price} лв.");
        }



    }
}
