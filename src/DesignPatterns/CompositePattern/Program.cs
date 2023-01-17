using CompositePattern.Models;
using System;

namespace CompositePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Composite!");

            Rectangle p1 = new Rectangle();
            Rectangle p2 = new Rectangle();
            Circle k1 = new Circle();

            Group g1 = new Group();
            g1.Add(p1);
            g1.Add(p2);
            g1.Add(k1);

            Rectangle p3 = new Rectangle();
            Rectangle p4 = new Rectangle();

            Group g2 = new Group();
            g2.Add(p3);
            g2.Add(p4);

            Group g = new Group();
            g.Add(g1);
            g.Add(g2);

            g.Move(10, 20);
        }
    }
}
