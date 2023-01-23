using System.Collections.Generic;

namespace VisitorPattern
{

    // Concrete Element
    public class Form : Control
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<Control> Body { get; set; }

        public override void Accept(IVisitor visitor)
        {
            foreach (var control in Body)
            {
                control.Accept(visitor);
            }
        }
    }

}
