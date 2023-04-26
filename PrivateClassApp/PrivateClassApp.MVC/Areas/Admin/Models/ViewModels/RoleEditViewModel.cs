using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrivateClassApp.MVC.Areas.Admin.Models.ViewModels
{
    public class RoleEditViewModel
    {
        public string Id { get; set; }
        [DisplayName("Rol Adı")]
        [Required(ErrorMessage = "Rol adı zorunludur")]
        public string Name { get; set; }

        [DisplayName("Rol Açıklaması")]
        [Required(ErrorMessage = "Rol açıklaması zorunludur")]
        public string Description { get; set; }
    }
}
