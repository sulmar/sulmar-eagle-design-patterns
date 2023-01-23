using System.Text;

namespace VisitorPattern
{
    // Concrete Visitor
    public class HtmlVisitor : IVisitor
    {
        private readonly StringBuilder builder = new StringBuilder();

        public HtmlVisitor()
        {
            builder.AppendLine("<html>");
            // builder.AppendLine($"<title>{Title}</title>";);

            builder.AppendLine("<body>");
        }

        public void Visit(Label control)
        {
            builder.AppendLine($"<span>{control.Caption}</span>");
        }

        public void Visit(TextBox control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>\"");
        }

        public void Visit(CheckBox control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>");
        }

        public void Visit(Button control)
        {
            builder.AppendLine($"<button><img src='{control.ImageSource}'/>{control.Caption}</button>");
        }

        private void AppendEndDocument()
        {
            builder.AppendLine("</body>");
            builder.AppendLine("</html>");
        }

        public string Output
        {
            get
            {
                AppendEndDocument();

                return builder.ToString();
            }
        }
    }


}
