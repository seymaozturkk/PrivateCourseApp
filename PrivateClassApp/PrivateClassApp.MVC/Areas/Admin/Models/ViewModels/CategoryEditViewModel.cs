using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrivateClassApp.MVC.Areas.Admin.Models.ViewModels
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad zorunludur")]
        public string Name { get; set; }
    }
}
