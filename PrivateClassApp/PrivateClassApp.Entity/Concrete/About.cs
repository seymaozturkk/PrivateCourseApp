using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class About
    {
        public int Id { get; set; }
        public string ShortInfo { get; set; }
        //[ForeignKey("Education")]
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public string Experience { get; set; }
        public Teacher Teacher { get; set; }
    }

    

}
