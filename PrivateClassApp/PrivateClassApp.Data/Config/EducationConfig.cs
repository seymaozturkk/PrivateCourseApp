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
    public class EducationConfig : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.HasData(
                new Education { Id=1, OtherEducations="Hafıza Teknikleri Eğitimi, Akıl ve Zeka Oyunları Eğitimi"},
                new Education { Id=2, OtherEducations="Anlayarak Hızlı Okuma Eğitimi"},
                new Education { Id=3, OtherEducations="Eğiticinin Eğitimi"},
                new Education { Id=4, OtherEducations="Hafıza Teknikleri Eğitimi, Satranç Eğitimi"},
                new Education { Id=5, OtherEducations="Yaratıcı Yazarlık Eğitimi"},
                new Education { Id=6, OtherEducations="Çan Eğitimi"},
                new Education { Id=7, OtherEducations="Osmanlı Türkçesi Eğitimi"},
                new Education { Id = 8},
                new Education { Id=9, OtherEducations="Hafıza Teknikleri Eğitimi"},
                new Education { Id=10, OtherEducations= "Eğiticinin Eğitimi" },
                new Education { Id=11, OtherEducations="Öğrenci Koçluğu Eğitimi, Oyun Terapisi Eğitimi"},
                new Education { Id=12},
                new Education { Id=13, OtherEducations="Bitki Bilimleri Eğitimi"},
                new Education { Id=14, OtherEducations="Organik Kimya Eğitimi"},
                new Education { Id=15},
                new Education { Id = 16, OtherEducations = "Organik Kimya Eğitimi" }
            );
        }
    }
}
