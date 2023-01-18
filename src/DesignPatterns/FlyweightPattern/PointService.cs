using FlyweightPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public interface IPointService
    {
        IEnumerable<Point> GetAll();
    }

    public class PointService : IPointService
    {
        private readonly IEnumerable<Point> _points;

        public PointService(PointIconFactory factory)
        {
            _points = new List<Point>
            {
                new Point(10, 20, factory.Get(PointType.Cafe)),
                new Point(20, 40, factory.Get(PointType.Cafe)),
                new Point(21, 39, factory.Get(PointType.Parking)),
            };
        }

        public IEnumerable<Point> GetAll()
        {
            return _points;
        }
    }
}
