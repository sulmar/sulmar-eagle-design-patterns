namespace VisitorPattern
{
    // Abstract Element
    public abstract class Control
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public abstract void Accept(IVisitor visitor);

        //public ControlType Type { get; set; }
        //public string Value { get; set; }
        //public string ImageSource { get; set; }
    }

    // Concrete Element
    public class Label : Control
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Element
    public class TextBox : Control
    {
        public string Value { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Element
    public class CheckBox : Control
    {
        public bool Value { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Element
    public class Button : Control
    {
        public string ImageSource { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
