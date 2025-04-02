using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_EF.models
{
    public class Student : Person
    {
        public string StudentNumber { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
