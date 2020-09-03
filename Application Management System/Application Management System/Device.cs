using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Management_System
{
    class Device
    {
        int id;
        String OS, name;
        decimal capacity, ram;

        public Device()
        {
            capacity = 0;
            ram = 0;
            id = 0;
            OS = "";
            name = "";
        }
        public int getID()
        {
            return id;
        }

        public void setID(int id)
        {
            this.id = id;
        }
        public String getOS()
        {
            return OS;
        }

        public void setOS(String OS)
        {
            this.OS = OS;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public decimal getCapacity()
        {
            return capacity;
        }

        public void setCapacity(decimal capacity)
        {
            this.capacity = capacity;
        }

        public decimal getRam()
        {
            return ram;
        }

        public void setRam(decimal ram)
        {
            this.ram = ram;
        }

        public decimal ConvertToKB(decimal size, string capacity)
        {
            if (capacity == "KB")
                return size;
            else if (capacity == "MB")
                return size * 1024;
            else if (capacity == "GB")
                return size * 1024 * 1024;
            else if (capacity == "TB")
                return size * 1024 * 1024;
            return size;
        }
    }
}
