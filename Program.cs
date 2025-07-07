using System.Diagnostics.Metrics;

namespace SportEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            UI.SelectOption();
            new Data();
            string input;

            while ((input = Console.ReadLine()) != "0")
            {

                switch (input)
                {
                    case "1": //добавяне на събитие
                        Functions.AddEvent();
                        break;
                    case "2": //Продажба на билет
                        Functions.BuyTickets();
                        break;
                    case "3": // проверка на наличноста на билетите
                        Functions.ShowAvailability(); 
                        break;          
                    case "4": //Справка
                        UI.ShowAllEvents(Data.events);
                        break;
                    case "5":
                        Functions.Budget();
                        break;
                    case "0": //kak da zatvorim programata
                        break;
                    case "m":
                        UI.SelectOption();
                        break;
                    default: Console.WriteLine("Напиши цифра от 1-5 или X за да продължиш или затвориш"); break;

                }


            }
        }
    }
}


