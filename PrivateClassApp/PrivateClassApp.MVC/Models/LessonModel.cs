using PrivateClassApp.Entity.Concrete;

namespace PrivateClassApp.MVC.Models
{
    public class LessonModel
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public Teacher Teacher { get; set; }
        public List<Category> Categories { get; set; }
    }
}
