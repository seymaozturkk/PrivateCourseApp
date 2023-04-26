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
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ZoomLink { get; set; }
        public EnumReservationState ReservationState { get; set; }

    }

    public enum EnumReservationState
    {
        Geçmiş, Aktif
    }
}
