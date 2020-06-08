using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sqlConnectionDAL
{
   public class sqlBgl
    {
        public SqlConnection baglanti()
        {
            SqlConnection bgl = new SqlConnection("@Data Source=DESKTOP-B86EPKP\\SQLEXPRESS01;Initial Catalog=EmployeeDB;Integrated Security=True");
            bgl.Open();
            return bgl;
        }

    }
}
