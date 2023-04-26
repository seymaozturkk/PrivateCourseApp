using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Config
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.TeacherId).IsRequired();

            builder.HasData(
                new Lesson { Id=1, CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now, Name="Matematik", Url="matematik", Price=400, Description="11. ve 12. Sınıf üniversiteye hazırlık çalışması", TeacherId=1 },
                new Lesson { Id = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Edebiyat", Url = "edebiyat", Price = 400, Description = "Lise ve üniversite öğrencileri için edebiyat dersleri", TeacherId = 2 },
                new Lesson { Id = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "İngilizce", Url = "ingilizce", Price = 500, Description = "İngilizce öğrenmek isteyenler için dersler", TeacherId = 3 },
                new Lesson { Id = 4, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Matematik", Url = "matematik-2", Price = 400, Description = "Lise öğrencileri için temel matematik dersi", TeacherId = 4 },
                new Lesson { Id = 5, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Türkçe", Url = "turkce", Price = 350, Description = "Lise ve üniversite öğrencileri için Türkçe dersleri", TeacherId = 5 },
                new Lesson { Id = 6, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Müzik (Klasik)", Url = "muzik-klasik", Price = 300, Description = "Klasik müzik üzerine temel bir ders", TeacherId = 6 },
                new Lesson { Id = 7, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Edebiyat (Modern)", Url = "edebiyat-modern", Price = 250, Description = "Modern edebiyatın önemli eserlerine yönelik bir ders", TeacherId = 7 },
                new Lesson { Id = 8, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "İngilizce (Konuşma Pratiği)", Url = "ingilizce-konusma-pratigi", Price = 300, Description = "Konuşma pratiği üzerine odaklanan İngilizce dersi", TeacherId = 8 },
                new Lesson { Id = 9, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Fen Bilimleri", Url = "fen-bilimleri", Price = 400, Description = "11. ve 12. Sınıf üniversiteye hazırlık çalışması", TeacherId = 9 },
                new Lesson { Id = 10, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Sosyal Bilimler", Url = "sosyal-bilimler", Price = 450, Description = "Lise ve üniversite öğrencileri için sosyal bilimler dersi", TeacherId = 10 },
                new Lesson { Id = 11, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Psikoloji", Url = "psikoloji", Price = 500, Description = "Lise ve üniversite öğrencileri için psikoloji dersi", TeacherId = 11 },
                new Lesson { Id = 12, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Piyano Dersi", Url = "piyano-dersi", Price = 400, Description = "Piyano çalmayı öğrenmek isteyenler için temel bir ders", TeacherId = 12 },
                new Lesson { Id = 13, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Biyoloji", Url = "biyoloji", Price = 400, Description = "11. ve 12. Sınıf üniversiteye hazırlık çalışması", TeacherId = 13 },
                new Lesson { Id = 14, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Kimya", Url = "kimya", Price = 450, Description = "11. ve 12. Sınıf üniversiteye hazırlık çalışması", TeacherId = 14 },
                new Lesson { Id = 15, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Fizik", Url = "fizik", Price = 450, Description = "11. ve 12. Sınıf üniversiteye hazırlık çalışması", TeacherId = 15 },
                new Lesson { Id = 16, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Organik Kimya", Url = "organik-kimya", Price = 350, Description = "Organik kimya konularına yönelik bir ders", TeacherId = 16 }
            );
        }
    }
}
