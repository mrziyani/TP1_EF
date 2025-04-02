using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_EF
{
    public class TeacherSubjectViewModel
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
    }

}
