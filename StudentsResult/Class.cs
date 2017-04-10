using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsResult
{
    public class Class
    {
        public string ClassName { get; set; }
        public Term Term { get; set; }

    }
   public enum Term
    {
       First,
       Second,
       Third
    }
}
