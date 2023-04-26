using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;

namespace PrivateClassApp.MVC.Areas.Admin.Models.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Teacher Teacher { get; set; }
        public User User { get; set; }
    }
}
