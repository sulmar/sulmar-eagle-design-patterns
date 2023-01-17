using FactoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public static class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Hello Factory Pattern!");

            while (true)
            {
                Console.WriteLine("Podaj typ wizyty lekarskiej");
                string visitType = Console.ReadLine();

                Console.WriteLine("Podaj czas trwania (w min.)");
                TimeSpan duration = TimeSpan.FromMinutes(int.Parse(Console.ReadLine()));

                Visit visit = VisitFactory.Create(visitType);

                decimal amount = visit.CalculateCost(duration);

                // Console.ForegroundColor = ConsoleColorFactory.Create(amount);

                IConsoleColorAbstractFactory colorFactory;

                if (DateTime.Now.Hour is > 23 or < 6)
                {
                    colorFactory = new DarkModeConsoleColorFactory();
                }
                else
                {
                    colorFactory = new LightModeConsoleColorFactory();
                }

                Console.ForegroundColor = colorFactory.Create(amount);

                Console.WriteLine($"Należność {amount:C2}");

                Console.ResetColor();
            }

            
        }

    }
}
