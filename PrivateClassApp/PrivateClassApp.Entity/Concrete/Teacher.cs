using PrivateClassApp.Entity.Abstract;
using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PrivateClassApp.Entity.Concrete
{
    public class Teacher
    {
        public int Id { get; set; }
        //[ForeignKey("About")]
        public int AboutId { get; set; }
        public About About { get; set; }
        public string Title { get; set; }
        public bool IsApproved { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<TeacherAvailability> TeacherAvailabilities { get; set; }

    }
}
