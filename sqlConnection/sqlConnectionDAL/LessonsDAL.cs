using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sqlConnectionDAL
{
   public class LessonsDAL
    {
        
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-B86EPKP\\SQLEXPRESS01; Initial Catalog = EmployeeDB; Integrated Security = True");       
        public DataTable GetStudentLessonName(int id)    
        {
        string sql = string.Format(@"select L.LessonID,L.LessonName,B.Note,B.BaglantiID,E.EmployeeID
                            from Employee E join Baglanti B ON B.EmployeeID=E.EmployeeID
				                            join Lesson L on L.LessonID=B.LessonID
                            WHERE E.EmployeeID={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "Dersler :  ";
            return dt;
        }
        public DataTable GetAllInfo(int id)
        {
            string sql = string.Format(@"select * from Employee E , Lesson L where EmployeeID={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "Butun Bilgiler:";
            return dt;
        }
        public DataTable GetAllStudent()
        {
            SqlCommand cmd = new SqlCommand();
            string sql = string.Format(@"  select  E.EmployeeID, L.LessonName,L.LessonID,B.Note from Lesson L  join  Baglanti B ON B.LessonID=L.LessonID
											 join Employee E ON B.EmployeeID=E.EmployeeID ");
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "ButunOgrenciler";
            return dt;
        }
        public DataTable GetButunDersler()
        {
            SqlCommand cmd = new SqlCommand();
            string sql = string.Format(@"select LessonID,LessonName from Lesson ");
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "Dersler";
            return dt;
        }
        public void DeleteStudentInfo(int id)
        {
            bgl.Open();
            string sql = string.Format(@"delete from Baglanti where BaglantiID={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.DeleteCommand = new SqlCommand(sql, bgl);
            adp.DeleteCommand.ExecuteNonQuery();
            bgl.Close();
        }
        public DataTable UpdateLessonInfo(BaglantiRequestModel baglantiModel)
        {            
                bgl.Open();
                string sql = string.Format(@"update Baglanti set LessonID={0},Note={1} where  BaglantiID={2} ", baglantiModel.LessonID, baglantiModel.Note, baglantiModel.BaglantiID);
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.UpdateCommand = new SqlCommand(sql, bgl);
                adp.UpdateCommand.ExecuteNonQuery();
                dt.TableName = "Ders Güncelle";
                bgl.Close();
                return dt;         
        }
        public DataTable CreateLesson(BaglantiRequestModel model)
        {
            bgl.Open();
            string sql = string.Format(@"insert into Baglanti(EmployeeID,LessonID,Note) values ({0},{1},{2})",model.EmployeeID,model.LessonID,model.Note);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.InsertCommand = new SqlCommand(sql, bgl);
            adp.InsertCommand.ExecuteNonQuery();
            dt.TableName = "Eklenen Dersler";
            bgl.Close();
            return dt;
        }
        public DataTable GetOgrAdSoyad(int id)
        {
            bgl.Open();
            SqlCommand cmd = new SqlCommand();
            string sql = string.Format(@" select EmployeeID,Name,Surname from Employee where EmployeeID={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt.TableName = "Ad_Soyad";
            bgl.Close();
            return dt;
        }
        public DataTable GetRefreshStudent(int id)
        {
            {
                bgl.Open();                
                string sql = string.Format(@"select L.LessonID,L.LessonName,B.Note,B.BaglantiID
                            from Employee E join Baglanti B ON B.EmployeeID=E.EmployeeID
				                            join Lesson L on L.LessonID=B.LessonID
                            WHERE E.EmployeeID={0}", id);
                SqlDataAdapter adp = new SqlDataAdapter(sql, bgl);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dt.TableName = "Dersler :  ";
                bgl.Close();
                return dt;
            }
        }
    }
}
