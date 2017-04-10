using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult
{
   public class Subject
    {
        public string SubjectName { get; set; }

        //students admission number and score
        public Dictionary<string, float> CA { get; set; }
        public Dictionary<string, float> Exam { get; set; }
        public float ClassAverage { get; set; }
        public Dictionary<string, float> Position { get; set; }


    }
}
