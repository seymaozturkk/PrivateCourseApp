using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class LessonLike
    {
        //Hangi Lesson hangi User tarafından beğenilmiş
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
