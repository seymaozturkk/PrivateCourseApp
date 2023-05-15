using PrivateClassApp.Entity.Concrete;

namespace PrivateClassApp.MVC.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ZoomLink { get; set; }
    }
}
