using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    public abstract class Component
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public abstract void Draw();
        public abstract void Move(int offsetX, int offsetY);
    }

    public abstract class Leaf : Component
    {
        public override void Move(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }
    }

    public class Rectangle : Leaf
    {
        public override void Draw()
        {
            Console.WriteLine($"Draw Rectangle {Title} at ({X},{Y}");
        }
    }

    public class Circle : Leaf
    {
        public override void Draw()
        {
            Console.WriteLine($"Draw Circle {Title} at ({X},{Y}");
        }
    }


    public abstract class Composite : Component
    {
        private ICollection<Component> children { get; set; }

        public Composite()
        {
            children = new List<Component>();
        }

        public override void Move(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;

            foreach (var component in children)
            {
                component.Move(offsetX, offsetY);
            }
        }

        public override void Draw()
        {
            foreach (var component in children)
            {
                component.Draw();
            }
        }

        public void Add(Component component)
        {
            children.Add(component);
        }


    }

    public class Group : Composite
    {      
        
    }


}
