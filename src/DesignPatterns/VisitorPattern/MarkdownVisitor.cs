using System.Text;

namespace VisitorPattern
{
    // Concrete Visitor
    public class MarkdownVisitor : IVisitor
    {
        private readonly StringBuilder builder = new StringBuilder();

        public void Visit(Label control)
        {
            builder.AppendLine($"**{control.Caption}**");
        }

        public void Visit(TextBox control)
        {
            builder.AppendLine($"*{control.Caption}* {control.Value}");
        }

        public void Visit(CheckBox control)
        {

        }

        public void Visit(Button control)
        {
            throw new System.NotImplementedException();
        }

        public string Output => builder.ToString();
    }


}
