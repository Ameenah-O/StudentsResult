using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult
{
    public class StudentSubjectScore
    {
        public Subject Subject { get; set; }
        public string AdmissionNumber { get; set; }
        public float CA { get; set; }
        public float Exam { get; set; }
        public float Total { get; set; }
        public int Position { get; set; }
    }
}
