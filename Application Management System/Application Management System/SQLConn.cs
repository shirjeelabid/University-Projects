using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Management_System
{
    class SQLConn
    {
        public static SqlConnection con1;
        public SqlConnection con;
        public static SQLConn obj;
        private SQLConn()
        {
            //con=new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
            //con = new SqlConnection(@"Data Source=HAROONGABAENVY\MSSQLSERVER1;Initial Catalog=ApplicationManagementSystem;Integrated Security=True;multipleactiveresultsets=true");
        }
        public static SQLConn getInstance()
        {
            con1 = new SqlConnection(@"Data Source=DESKTOP-KIMKVP2;Initial Catalog=ApplicationManagementSystem;Integrated Security=True;multipleactiveresultsets=true");
            
            if (obj == null)
                obj = new SQLConn();
            return obj;
        }
        public void assign()
        {
            con = con1;
        }
        
    }
}
