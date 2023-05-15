using PrivateClassApp.Entity.Concrete;

namespace PrivateClassApp.MVC.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public About About { get; set; }
        public string Title { get; set; }
        public bool IsApproved { get; set; }
        public string ImageUrl { get; set; }
        public List<LessonModel> Lessons { get; set; }
        public List<TeacherAvailability> TeacherAvailabilities { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
