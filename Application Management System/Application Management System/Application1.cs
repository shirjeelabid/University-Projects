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

    class Application1
    {
        
        int id;
        decimal price;
        String name, description, version, category, rating,devName;
        public Device dev;
        public Application1()
        {
            dev = new Device();
        }
        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void setPrice(decimal price) {
            this.price = price;
        }
        public decimal getPrice()
        {
            return price;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getdevName()
        {
            return devName;
        }
        public void setdevName(String devname)
        {
            this.devName = devname;
        }
        public String getDescription()
        {
            return description;
        }
        public void setDescription(String description)
        {
            this.description = description;
        }
        public String getVersion()
        {
            return version;
        }
        public void setVersion(String version)
        {
            this.version = version;
        }
        public String getCategory()
        {
            return category;
        }
        public void setCategory(String category)
        {
            this.category = category;
        }
        public String getRating()
        {
            return rating;
        }
        public void setRating(String rating)
        {
            this.rating = rating;
        }
       
    }
}
