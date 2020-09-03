using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Management_System
{
    class Customer:Person
    {
        
        public Device device;
        public Application1 app;
        public Customer()
        {
            device = new Device();
            app = new Application1();
        }
    }
}
