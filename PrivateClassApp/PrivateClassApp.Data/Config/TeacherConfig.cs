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
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsApproved).IsRequired();
            builder.Property(x => x.UserId).IsRequired();


            //builder.HasData(
            //    new Teacher { UserId = "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7", AboutId = 1, Title = "Matematik Öğretmeni", IsApproved = true, ImageUrl = "ali-yilmaz.jpg" },
            //    new Teacher { UserId = "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10", AboutId = 2, Title = "Edebiyat Öğretmeni", IsApproved = true, ImageUrl = "ayse-demir.jpg" },
            //    new Teacher { UserId = "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4", AboutId = 3, Title = "İngilizce Öğretmeni", IsApproved = true, ImageUrl = "mehmet-kaya.jpg" },
            //    new Teacher { UserId = "a17a2a35-1b72-42af-8d68-0b55faa60f22", AboutId = 4, Title = "Matematik Öğretmeni", IsApproved = true, ImageUrl = "elif-sahin.jpg" },
            //    new Teacher { UserId = "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2", AboutId = 5, Title = "Türkçe Öğretmeni", IsApproved = true, ImageUrl = "mustafa-arslan.jpg" },
            //    new Teacher { UserId = "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5", AboutId = 6, Title = "Müzik Öğretmeni", IsApproved = true, ImageUrl = "gizem-aksoy.jpg" },
            //    new Teacher { UserId = "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1", AboutId = 7, Title = "Edebiyat Öğretmeni", IsApproved = true, ImageUrl = "burak-gunes.jpg" },
            //    new Teacher { UserId = "d10e29b9-9f64-444d-8d0c-7a69e00e13b7", AboutId = 8, Title = "İngilizce Öğretmeni", IsApproved = true, ImageUrl = "esra-gultekin.jpg" },
            //    new Teacher { UserId = "a0d9c91b-3e6c-4528-a31e-58a47be27108", AboutId = 9, Title = "Fen Bilimleri Öğretmeni", IsApproved = true, ImageUrl = "emre-ozturk.jpg" },
            //    new Teacher { UserId = "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd", AboutId = 10, Title = "Sosyal Bilimler Öğretmeni", IsApproved = true, ImageUrl = "selin-kocak.jpg" },
            //    new Teacher { UserId = "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f", AboutId = 11, Title = "Psikoloji Öğretmeni", IsApproved = true, ImageUrl = "deniz-sahin.jpg" },
            //    new Teacher { UserId = "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d", AboutId = 12, Title = "Müzik Öğretmeni", IsApproved = true, ImageUrl = "beyza-karaca.jpg" },
            //    new Teacher { UserId = "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd", AboutId = 13, Title = "Biyoloji Öğretmeni", IsApproved = true, ImageUrl = "yasin-kilic.jpg" },
            //    new Teacher { UserId = "8a55c638-baff-413a-bdb9-b9b41f768b71", AboutId = 14, Title = "Kimya Öğretmeni", IsApproved = true, ImageUrl = "zeynep-yilmaz.jpg" },
            //    new Teacher { UserId = "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad", AboutId = 15, Title = "Fizik Öğretmeni", IsApproved = true, ImageUrl = "serdar-kara.jpg" },
            //    new Teacher { UserId = "cc95335c-9a83-4a22-8f8e-b083dd6fc663", AboutId = 16, Title = "Kimya Öğretmeni", IsApproved = true, ImageUrl = "ayse-aydin.jpg" }

            //);

        }
    }
}
