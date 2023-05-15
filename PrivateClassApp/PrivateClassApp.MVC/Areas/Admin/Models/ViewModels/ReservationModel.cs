
using PrivateClassApp.Entity.Concrete.Identity;

namespace PrivateClassApp.MVC.Areas.Admin.Models.ViewModels
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public LessonViewModel Lesson { get; set; }
        public string UserId { get; set; }
        public User ReservationUser { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ZoomLink { get; set; }
    }
}
