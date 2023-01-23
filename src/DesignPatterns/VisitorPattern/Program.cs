using System;
using System.Collections.ObjectModel;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Visitor Pattern!");

            IVisitor visitor = new HtmlVisitor();

            Form form = Get();
            form.Accept(visitor);

            string html = visitor.Output;

            System.IO.File.WriteAllText("index.html", html);
        }

        public static Form Get()
        {
            Form form = new Form
            {
                Name = "/forms/customers",
                Title = "Design Patterns",

                Body = new Collection<Control>
                {

                   new Label { Caption = "Person", Name = "lblName" },
                    new TextBox { Caption = "FirstName", Name = "txtFirstName", Value = "John"},
                    new CheckBox { Caption = "IsAdult", Name = "chkIsAdult", Value = true },
                    new Button {  Caption = "Submit", Name = "btnSubmit", ImageSource = "save.png" },
                }

            };

            return form;
        }
    }

}
