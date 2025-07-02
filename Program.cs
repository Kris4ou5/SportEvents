using System.Diagnostics.Metrics;

namespace SportEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "x") 
            { 
              switch(input) 
              {
                    case "1": //добавяне на събитие
                        
                        break;
                    case "2": //Продажба на билет
                        Functions.BuyTicket();
                        break;
                    case "3": // проверка на наличноста на билетите
                        break;
                    case "4": //Справка
                        break;
                    case "5": //kak da zatvorim programata
                        break;
                    default: Console.WriteLine("Напиши цифра от 1-5 или X за да продължиш или затвориш");  break;
                
              }
            
            
            }
        }
    }
}
