namespace VisitorPattern
{
    // Abstract Visitor
    public interface IVisitor
    {
        void Visit(Label control);
        void Visit(TextBox control);
        void Visit(CheckBox control);
        void Visit(Button control);
        string Output { get; }
    }


}
