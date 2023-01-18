using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern.Models
{
    public class Point
    {
        public int X { get; }   // 4 bytes
        public int Y { get; }   // 4 bytes
        public PointIcon Icon { get; }

        public Point(int x, int y, PointIcon icon)
        {
            X = x;
            Y = y;            
            Icon = icon;
        }

        public void Draw() => Console.WriteLine($"{Icon.Type} at ({X},{Y})");
    }

    // Flyweight (pyłek)
    public class PointIcon
    {
        public PointType Type { get; } // 4 bytes
        public byte[] Icon { get; } // 10 kb

        public PointIcon(PointType type, byte[] icon)
        {
            Type = type;
            Icon = icon;
        }
    }

    public interface IPointIconFactory
    {
        PointIcon Get(PointType type);
    }

    public class PointIconFactory : IPointIconFactory 
    {
        private readonly Dictionary<PointType, PointIcon> _icons = new ();

        public PointIcon Get(PointType type)
        {
            if (!_icons.ContainsKey(type))
            {
                PointIcon icon = new PointIcon(type, null);
                // cafe.jpg
                // parking.jpg

                _icons.Add(type, icon);
            }

            return _icons[type];
        }
    }
    

    public enum PointType 
    {
        Cafe,
        Parking
    }
}
