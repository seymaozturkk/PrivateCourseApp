using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ZoomLink { get; set; }

    }

}
