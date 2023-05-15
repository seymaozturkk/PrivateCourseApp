using PrivateClassApp.Entity.Concrete;

namespace PrivateClassApp.MVC.Models
{
    public class TeacherAvailabilityModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public TimeSpan Time { get; set; }
        public EnumDay DayOfWeek { get; set; }
    }
}
