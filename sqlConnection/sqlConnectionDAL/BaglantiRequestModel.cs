using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlConnectionDAL
{
  public  class BaglantiRequestModel
    {
        public int BaglantiID { get; set; }
        public int EmployeeID { get; set; }
        public int LessonID { get; set; }
        public int Note { get; set; }
    }
}
