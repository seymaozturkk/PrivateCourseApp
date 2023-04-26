using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class Education
    {
        public int Id { get; set; }
        public List<UniversityEducation> UniversityEducations { get; set; }
        public string OtherEducations { get; set; }
        public About About { get; set; }
    }

}
