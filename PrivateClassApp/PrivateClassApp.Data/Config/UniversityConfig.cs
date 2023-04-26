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
    public class UniversityConfig : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.HasData(
                new University { Id=1, Name="İstanbul Üniversitesi"},
                new University { Id = 2, Name = "Boğaziçi Üniversitesi" },
                new University { Id = 3, Name = "Orta Doğu Teknik Üniversitesi" },
                new University { Id = 4, Name = "Bilkent Üniversitesi" },
                new University { Id = 5, Name = "Ankara Üniversitesi" },
                new University { Id = 6, Name = "Ege Üniversitesi" },
                new University { Id = 7, Name = "İzmir Yüksek Teknoloji Enstitüsü" },
                new University { Id = 8, Name = "Sabancı Üniversitesi" },
                new University { Id = 9, Name = "Koç Üniversitesi" },
                new University { Id = 10, Name = "Yıldız Teknik Üniversitesi" },
                new University { Id = 11, Name = "Hacettepe Üniversitesi" },
                new University { Id = 12, Name = "İstanbul Teknik Üniversitesi" },
                new University { Id = 13, Name = "Ondokuz Mayıs Üniversitesi" },
                new University { Id = 14, Name = "Dokuz Eylül Üniversitesi" },
                new University { Id = 15, Name = "Akdeniz Üniversitesi" },
                new University { Id = 16, Name = "Selçuk Üniversitesi" },
                new University { Id = 17, Name = "Adnan Menderes Üniversitesi" },
                new University { Id = 18, Name = "Çanakkale Onsekiz Mart Üniversitesi" },
                new University { Id = 19, Name = "Anadolu Üniversitesi" },
                new University { Id = 20, Name = "Erciyes Üniversitesi" },
                new University { Id = 21, Name = "Pamukkale Üniversitesi" },
                new University { Id = 29, Name = "Kadir Has Üniversitesi" },
                new University { Id = 31, Name = "İstanbul Medeniyet Üniversitesi" },
                new University { Id = 32, Name = "İstanbul Ticaret Üniversitesi" },
                new University { Id = 33, Name = "Kocaeli Üniversitesi" },
                new University { Id = 34, Name = "Atılım Üniversitesi" },
                new University { Id = 35, Name = "Bahçeşehir Üniversitesi" },
                new University { Id = 36, Name = "Beykent Üniversitesi" },
                new University { Id = 37, Name = "Bursa Teknik Üniversitesi" },
                new University { Id = 38, Name = "Çankaya Üniversitesi" },
                new University { Id = 39, Name = "Düzce Üniversitesi" },
                new University { Id = 40, Name = "Fırat Üniversitesi" },
                new University { Id = 41, Name = "Galatasaray Üniversitesi" },
                new University { Id = 42, Name = "Gazi Üniversitesi" },
                new University { Id = 43, Name = "Gebze Teknik Üniversitesi" },
                new University { Id = 44, Name = "Gediz Üniversitesi" },
                new University { Id = 45, Name = "İzmir Ekonomi Üniversitesi" },
                new University { Id = 46, Name = "İzmir Kâtip Çelebi Üniversitesi" },
                new University { Id = 47, Name = "Işık Üniversitesi" },
                new University { Id = 48, Name = "İzmir Bakırçay Üniversitesi" },
                new University { Id = 49, Name = "Maltepe Üniversitesi" },
                new University { Id = 50, Name = "Marmara Üniversitesi" },
                new University { Id = 51, Name = "Muğla Sıtkı Koçman Üniversitesi" },
                new University { Id = 52, Name = "Niğde Ömer Halisdemir Üniversitesi" },
                new University { Id = 53, Name = "Ordu Üniversitesi" },
                new University { Id = 54, Name = "Özyeğin Üniversitesi" },
                new University { Id = 55, Name = "Piri Reis Üniversitesi" },
                new University { Id = 56, Name = "Recep Tayyip Erdoğan Üniversitesi" },
                new University { Id = 57, Name = "Sakarya Üniversitesi" },
                new University { Id = 58, Name = "Sivas Cumhuriyet Üniversitesi" },
                new University { Id = 59, Name = "Trakya Üniversitesi" },
                new University { Id = 60, Name = "Üsküdar Üniversitesi" },
                new University { Id = 61, Name = "Yeditepe Üniversitesi" },
                new University { Id = 62, Name = "Yeni Yüzyıl Üniversitesi" },
                new University { Id = 63, Name = "Yıldızeli Üniversitesi" },
                new University { Id = 64, Name = "Yüzüncü Yıl Üniversitesi" },
                new University { Id = 65, Name = "Zirve Üniversitesi" },
                new University { Id = 66, Name = "İzmir Ekonomi Üniversitesi" },
                new University { Id = 67, Name = "İstanbul Bilgi Üniversitesi" },
                new University { Id = 68, Name = "Uludağ Üniversitesi" },
                new University { Id = 69, Name = "Harran Üniversitesi" },
                new University { Id = 70, Name = "İzmir Demokrasi Üniversitesi" },
                new University { Id = 71, Name = "Karadeniz Teknik Üniversitesi" },
                new University { Id = 72, Name = "Maltepe Üniversitesi" },
                new University { Id = 73, Name = "Mimar Sinan Güzel Sanatlar Üniversitesi" },
                new University { Id = 74, Name = "Abdullah Gül Üniversitesi" },
                new University { Id = 75, Name = "Ağrı İbrahim Çeçen Üniversitesi" },
                new University { Id = 76, Name = "Ahi Evran Üniversitesi" },
                new University { Id = 77, Name = "Akdeniz Karpaz Üniversitesi" },
                new University { Id = 78, Name = "Aksaray Üniversitesi" },
                new University { Id = 79, Name = "Alanya Alaaddin Keykubat Üniversitesi" },
                new University { Id = 80, Name = "Alanya Hamdullah Emin Paşa Üniversitesi" },
                new University { Id = 81, Name = "Alparslan Türkeş Bilim ve Teknoloji Üniversitesi" },
                new University { Id = 82, Name = "Altınbaş Üniversitesi" },
                new University { Id = 83, Name = "Amasya Üniversitesi" },
                new University { Id = 84, Name = "Anka Teknoloji Üniversitesi" },
                new University { Id = 85, Name = "Ankara Hacı Bayram Veli Üniversitesi" },
                new University { Id = 86, Name = "Ankara Medipol Üniversitesi" },
                new University { Id = 87, Name = "Ankara Sosyal Bilimler Üniversitesi" },
                new University { Id = 88, Name = "Antalya Akev Üniversitesi" },
                new University { Id = 89, Name = "Ardahan Üniversitesi" },
                new University { Id = 90, Name = "Artvin Çoruh Üniversitesi" },
                new University { Id = 91, Name = "Atatürk Üniversitesi" },
                new University { Id = 92, Name = "Atılım Üniversitesi" },
                new University { Id = 93, Name = "Avrasya Üniversitesi" },
                new University { Id = 94, Name = "Balıkesir Üniversitesi" },
                new University { Id = 95, Name = "Bandırma Onyedi Eylül Üniversitesi" },
                new University { Id = 96, Name = "Bartın Üniversitesi" },
                new University { Id = 97, Name = "Batman Üniversitesi" },
                new University { Id = 98, Name = "Bayburt Üniversitesi" },
                new University { Id = 99, Name = "Beykent Üniversitesi" },
                new University { Id = 100, Name = "Bezmiâlem Vakıf Üniversitesi" },
                new University { Id = 101, Name = "Bilecik Şeyh Edebali Üniversitesi" },
                new University { Id = 102, Name = "Bingöl Üniversitesi" },
                new University { Id = 103, Name = "Biruni Üniversitesi" },
                new University { Id = 104, Name = "Bolu Abant İzzet Baysal Üniversitesi" }
               
            );


        }
    }
}
