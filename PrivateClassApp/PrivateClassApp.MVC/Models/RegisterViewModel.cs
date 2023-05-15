﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PrivateClassApp.Entity.Concrete.Identity;

namespace PrivateClassApp.MVC.Models
{
    public class RegisterViewModel
    {
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
        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır!")]
        public string RePassword { get; set; }
        public EnumUserType UserType { get; set; }
    }
}
