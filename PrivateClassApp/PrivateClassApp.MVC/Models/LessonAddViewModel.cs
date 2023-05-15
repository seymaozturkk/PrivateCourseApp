﻿using PrivateClassApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrivateClassApp.MVC.Models
{
    public class LessonAddViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad zorunludur")]
        public string Name { get; set; }
        [DisplayName("Ücret")]
        [Required(ErrorMessage = "Ücret zorunludur")]
        public decimal? Price { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama zorunludur")]
        public string Description { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Kategori zorunludur")]
        public int[] SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
        public int TeacherId { get; set; }
    }
}
