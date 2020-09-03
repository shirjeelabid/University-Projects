
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Management_System
{
    class Developer:Person
    {
        public Application1 app;
        public Developer()
        {
            app = new Application1();
        }

    }
}
