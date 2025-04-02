using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TP1_EF.models
{
    public class Teacher : Person
    {
        public DateTime HireDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int test { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
