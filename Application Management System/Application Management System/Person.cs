using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Management_System
{
    class Person
    {

        int id;
        String name, email, gender, pswd, country, status, userType;
       
        public Person()
        {
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public String getGender()
        {
            return gender;
        }

        public void setGender(String gender)
        {
            this.gender = gender;
        }

        public String getPswd()
        {
            return pswd;
        }

        public void setPswd(String pswd)
        {
            this.pswd = pswd;
        }

        public String getCountry()
        {
            return country;
        }

        public void setCountry(String country)
        {
            this.country = country;
        }

        public String getStatus()
        {
            return status;
        }

        public void setStatus(String status)
        {
            this.status = status;
        }

        public String getUserType()
        {
            return userType;
        }

        public void setUserType(String userType)
        {
            this.userType = userType;
        }
    }
}
