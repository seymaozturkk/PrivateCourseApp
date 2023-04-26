namespace PrivateClassApp.MVC.Models
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
    }
}
