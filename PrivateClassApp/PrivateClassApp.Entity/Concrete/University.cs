using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UniversityEducation> UniversityEducations { get; set; }
    }
}
