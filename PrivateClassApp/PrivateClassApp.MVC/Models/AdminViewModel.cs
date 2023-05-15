using PrivateClassApp.Entity.Concrete.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PrivateClassApp.MVC.Models
{
	public class AdminViewModel
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad zorunludur")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad zorunludur")]
        public string LastName { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string UserName { get; set; }
        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        public DateTime BirthDate { get; set; }
        public EnumGender Gender { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Email Onayı")]
        public bool EmailConfirmed { get; set; }
    }
}
