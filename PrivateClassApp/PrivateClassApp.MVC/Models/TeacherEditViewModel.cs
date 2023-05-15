using PrivateClassApp.Entity.Concrete.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PrivateClassApp.Entity.Concrete;

namespace PrivateClassApp.MVC.Models
{
    public class TeacherEditViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad zorunludur")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad zorunludur")]
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Email Onayı")]
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public EnumGender Gender { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Kısa Bilgi")]
        [Required(ErrorMessage = "Kısa bilgi zorunludur")]
        [MinLength(100)]
        public string ShortInfo { get; set; }
        [DisplayName("Deneyim")]
        [Required(ErrorMessage = "Deneyim zorunludur")]
        public string Experience { get; set; }
        [DisplayName("Diğer Eğitimler")]
        [Required(ErrorMessage = "Diğer eğitimler zorunludur")]
        public string OtherEducations { get; set; }
        [DisplayName("Unvan")]
        [Required(ErrorMessage = "Unvan zorunludur")]
        public string Title { get; set; }
        public bool IsApproved { get; set; }
        public string ImageUrl { get; set; }
        [DisplayName("Resim")]
        public IFormFile Image { get; set; }
        public List<UniversityEducationModel> UniversityEducations { get; set; }
    }
}
