namespace PrivateClassApp.MVC.Models
{
    public class UserReservationsModel
    {
        public int Id { get; set; }
        public LessonModel Lesson { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ZoomLink { get; set; }
    }
}
