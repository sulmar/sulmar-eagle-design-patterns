using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class ContextApp : Singleton<ContextApp>
    {
        public string LoggedUser { get; set; }
        public DateTime LoggedOn { get; set; }

        public int SelectedDeviceId { get; set; }
        public int SelectedCustomerId { get; set; }
    }
}
