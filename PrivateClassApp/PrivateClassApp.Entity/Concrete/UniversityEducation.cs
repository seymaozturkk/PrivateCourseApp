using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class UniversityEducation
    {
        public University University { get; set; }
        public int UniversityId { get; set; }
        public string Description { get; set; }
        public Education Education { get; set; }
        public int EducationId { get; set; }
    }
}
