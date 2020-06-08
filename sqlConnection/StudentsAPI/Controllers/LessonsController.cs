using sqlConnectionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsAPI.Controllers
{
    public class LessonsController : ApiController
    {
        LessonsDAL lessonsDAL = new LessonsDAL();

        public DataTable GetRefreshStudent(int id)
        {
            return lessonsDAL.GetRefreshStudent(id);
        }


        public DataTable GetStudentInfo(int id)
        {
            return lessonsDAL.GetStudentLessonName(id);
        }
        public DataTable GetAllInfo(int id)
        {
            return lessonsDAL.GetAllInfo(id);
        }
        public DataTable GetStudent()
        {
            return lessonsDAL.GetAllStudent();
        }
        public DataTable GetButunDersler()
        {
            return lessonsDAL.GetButunDersler();
        }


        public DataTable GetOgrAdSoyad(int id)
        {
            return lessonsDAL.GetOgrAdSoyad(id);
        }

        [HttpGet]
        public void DeleteStudentInfo(int id)
        {
             lessonsDAL.DeleteStudentInfo(id);
        }
        [HttpPut]
        public DataTable UpdateBaglantiRecord(BaglantiRequestModel model)
        {
            return lessonsDAL.UpdateLessonInfo(model);
        }

        public DataTable cretaeStudentInfo(BaglantiRequestModel model)
        {
            return lessonsDAL.CreateLesson(model);
        }
        
    }
}
