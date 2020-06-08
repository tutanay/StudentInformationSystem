using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sqlConnectionDAL
{
  public  class StudentsDAL
    {
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-B86EPKP\\SQLEXPRESS01; Initial Catalog = EmployeeDB; Integrated Security = True");    
        public DataTable GetAllStudents()
       {
            SqlCommand cmd = new SqlCommand();
            string sql = string.Format(@"SELECT * FROM Employee");
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "Students";
            return dt;          
        }
        public DataTable GetStudentsByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            string sql = string.Format(@"select * from Employee  E where E.EmployeeID={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "ID ";
            return dt;
        }
        public DataTable UpdateStudents( StudentsRequestModel requestModel)
        {
            bgl.Open();           
            string sql = string.Format(@"update Employee set Name='{0}',Surname='{1}',Number={2} where EmployeeID={3}",requestModel.Name,requestModel.Surname,requestModel.Number,requestModel.EmployeeID);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
           
            adp.UpdateCommand = new SqlCommand(sql, bgl);
            adp.UpdateCommand.ExecuteNonQuery();
            dt.TableName = "Updates";
            bgl.Close();
            return dt;
        }
        public DataTable CreateStudents(StudentsRequestModel requestModel)
        {
            bgl.Open();
            string sql = string.Format(@"insert into Employee (Name,Surname,Number) values('{0}','{1}',{2})",requestModel.Name,requestModel.Surname,requestModel.Number);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();            
            adp.InsertCommand = new SqlCommand(sql, bgl);
            adp.InsertCommand.ExecuteNonQuery();           
            dt.TableName = "Created";
            bgl.Close();
            return dt;
        }
        public void DeleteStudents(int id)
        {
            bgl.Open();
            string sql = string.Format(@"delete from Employee  where EmployeeID={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.DeleteCommand = new SqlCommand(sql, bgl);
            adp.DeleteCommand.ExecuteNonQuery();
            bgl.Close();
        }
    }
}
