using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sqlConnectionDAL;

namespace StudentsAPI.Controllers
{
    public class StudentsController : ApiController
    {
        
        StudentsDAL studentsDAL = new StudentsDAL();

        public DataTable GetEmployee()
        {
          return   studentsDAL.GetAllStudents();
        }
        public DataTable GetEmployee(int id)
        {
            return studentsDAL.GetStudentsByID(id);
        }
        public DataTable PutEmployee(StudentsRequestModel requestModel)
        {
            return studentsDAL.UpdateStudents(requestModel);
        }
       
        public DataTable PostEmployee(StudentsRequestModel requestModel)
        {
            return studentsDAL.CreateStudents(requestModel);
        }
        public void DeleteEmployeee(int id)
        {
            studentsDAL.DeleteStudents(id);
        }
      
       
     
        
        
        
        
        
        
    
    }
}
