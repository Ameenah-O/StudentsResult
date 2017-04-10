using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult
{
    public class Student
    {
        public string Name { get; set; }
        public string AdmissionNumber { get; set; }
        public float TotalPercent { get; set; }
        public int Position { get; set; }
        public List<StudentSubjectScore> OfferedSubject {get; set;}

    }
}
