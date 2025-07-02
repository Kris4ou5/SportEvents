using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents
{
    internal class Functions
    {

        public static void AddEvent()
        {

       
            Console.WriteLine("--- Добавяне на ново събитие ---");

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
                    Console.WriteLine("Невалиден брой билети. Моля, въведете положително число.");
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
                    Console.WriteLine("Невалидна цена. Моля, въведете положително число.");
                }
            }



        }
    }
}


       