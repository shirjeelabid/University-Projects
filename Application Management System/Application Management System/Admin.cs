using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Management_System
{
    class Admin:Person
    {
        public Application1 appObj;
        public Customer cusObj;
        public Developer devObj;
        public Permissions permissionObj;
        public Admin()
        {
            appObj = new Application1();
            cusObj = new Customer();
            devObj = new Developer();
            permissionObj = new Permissions();
        }

        ~Admin()
        {
           
        }

    }
}
