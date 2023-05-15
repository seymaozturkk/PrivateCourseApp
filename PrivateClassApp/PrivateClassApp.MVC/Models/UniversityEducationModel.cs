using PrivateClassApp.Entity.Concrete;

namespace PrivateClassApp.MVC.Models
{
    public class UniversityEducationModel
    {
        public University University { get; set; }
        public string Description { get; set; }
        public Education Education { get; set; }
    }
}
