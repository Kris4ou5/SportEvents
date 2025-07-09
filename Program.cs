using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SportEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задаване на кодировка на конзолата, за да се поддържат символи на кирилица
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Показване на меню с наличните опции
            UI.SelectOption();

            // Инициализация на данните (предполагаемо зареждане на събития и други данни)
            new Data();

            string input;

            // Четене на потребителски вход докато не бъде въведено "0" (изход от програмата)
            while ((input = Console.ReadLine()) != "0")
            {
              
                // Изпълняване на действие според избраната опция от менюто
                switch (input)
                {
                    case "1": // Добавяне на ново спортно събитие
                        Functions.AddEvent();
                        break;
                    case "2": // Продажба на билет за събитие
                        Functions.BuyTickets();
                        break;
                    case "3": // Проверка на наличността на билетите за събитията
                        Functions.ShowAvailability();
                        break;
                    case "4": // Показване на списък с всички събития
                        UI.ShowAllEvents(Data.events);
                        break;
                    case "5": // Показване на текущия бюджет (приходи от продажба на билети)
                        Functions.Budget();
                        break;                  
                    case "m": // Повторно показване на менюто с опциите
                        UI.SelectOption();
                        break;
                    default:
                        // При невалидна опция се показва съобщение и вероятно затваря програмата
                        Console.WriteLine("Напиши цифра от 1-5 или 0 за да продължиш или затвориш");
                        break;
                }
            }
            Functions.CloseProgram(); //Затваря програмата тъй като щом кода излиза от while-a значи е подадено 0 като инпут

        }
    }
}
