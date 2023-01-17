using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class ConsoleColorFactory
    {
        public static ConsoleColor Create(decimal amount) => amount switch
        {
            < 200 => ConsoleColor.Green,
            > 200 and <= 500 => ConsoleColor.Yellow,
            > 500 => ConsoleColor.Red,
            _ => ConsoleColor.White
        };
    }

    // Abstract Factory
    public interface IConsoleColorAbstractFactory
    {
        ConsoleColor Create(decimal amount);
    }

    // Conrete Factory
    public class LightModeConsoleColorFactory : IConsoleColorAbstractFactory
    {
        public ConsoleColor Create(decimal amount) => amount switch
        {
            < 200 => ConsoleColor.Green,
            > 200 and <= 500 => ConsoleColor.Yellow,
            > 500 => ConsoleColor.Red,
            _ => ConsoleColor.White
        };        
    }

    // Conrete Factory
    public class DarkModeConsoleColorFactory : IConsoleColorAbstractFactory
    {
        public ConsoleColor Create(decimal amount) => amount switch
        {
            < 200 => ConsoleColor.DarkGreen,
            > 200 and <= 500 => ConsoleColor.DarkYellow,
            > 500 => ConsoleColor.DarkRed,
            _ => ConsoleColor.Black
        };
    }
}
