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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Category { Id = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Edebiyat", Url = "edebiyat" },
                new Category { Id = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Matematik", Url = "matematik" },
                new Category { Id = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Edebiyat", Url = "edebiyat" },
                new Category { Id = 4, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Müzik", Url = "muzik" },
                new Category { Id = 5, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Türkçe", Url = "turkce" },
                new Category { Id = 6, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Kimya", Url = "kimya" },
                new Category { Id = 7, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Biyoloji", Url = "biyoloji" },
                new Category { Id = 8, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Fizik", Url = "fizik" },
                new Category { Id = 9, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "İngilizce", Url = "ingilizce" },
                new Category { Id = 10, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Fen Bilimleri", Url = "fen-bilimleri" },
                new Category { Id = 11, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Sosyal Bilimler", Url = "sosyal-bilimler" },
                new Category { Id = 12, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Name = "Psikoloji", Url = "psikoloji" }
            );
        }
    }
}
