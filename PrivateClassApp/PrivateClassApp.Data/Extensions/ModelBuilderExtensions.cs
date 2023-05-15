using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri
            List<Role> roles = new List<Role>
            {
                new Role{Name="Admin", Description="Yöneticiler", NormalizedName="ADMIN"},
                new Role{Name="User", Description="Kullanıcılar", NormalizedName="USER"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User{ Id = "715d80fc-4fff-4509-8f89-ea1d4c0b03de", FirstName="Şeyma", LastName="Cankuş",NormalizedName="SEYMACANKUS", Url="seyma-cankus", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1999,11,12),Gender=EnumGender.Kadın, UserType=(EnumUserType)0, UserName="seymacankus", NormalizedUserName="SEYMACANKUS", Email= "cankusseyma@gmail.com", NormalizedEmail="CANKUSSEYMA@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7", FirstName="Ali", LastName="Yılmaz",NormalizedName="ALIYILMAZ", Url="ali-yilmaz", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1995,3,12),Gender=EnumGender.Erkek, UserType=(EnumUserType)2, UserName="aliyilmaz", NormalizedUserName="ALIYILMAZ", Email= "aliyilmaz@hotmail.com", NormalizedEmail="ALIYILMAZ@HOTMAIL.COM", EmailConfirmed=true},

                new User{ Id = "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10", FirstName="Ayşe", LastName="Demir",NormalizedName="AYSEDEMIR", Url="ayse-demir",        CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime   (1997,8,25),Gender=EnumGender.Kadın,      UserType=(EnumUserType) 2,  UserName="ayse.demir", NormalizedUserName="AYSEDEMIR",  Email= "ayse.demir@gmail.com",      NormalizedEmail="AYSE.DEMIR@GMAIL.COM",    EmailConfirmed=true},

                new User{ Id = "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4", FirstName="Mehmet", LastName="Kaya",NormalizedName="MEHMETKAYA",  Url="mehmet-kaya",     CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime      (1994,6,8),Gender=EnumGender.Erkek,  UserType=(EnumUserType) 2,    UserName="mehmet.kaya", NormalizedUserName="MEHMETKAYA",   Email=    "m.kaya@hotmail.com",     NormalizedEmail="M.KAYA@HOTMAIL.COM",    EmailConfirmed=true},

                new User{ Id = "a17a2a35-1b72-42af-8d68-0b55faa60f22", FirstName="Elif", LastName="Şahin",NormalizedName="ELIFSAHIN", Url="elif-sahin",        CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime   (2000,1,15),Gender=EnumGender.Kadın,      UserType=(EnumUserType) 2,  UserName="elif.sahin", NormalizedUserName="ELIFSAHIN",  Email= "elifsahin@gmail.com",   NormalizedEmail="ELIFSAHIN@GMAIL.COM",     EmailConfirmed=true},

                new User{ Id = "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2", FirstName="Mustafa", LastName="Arslan",NormalizedName="MUSTAFAARSLAN", Url="mustafa-arslan", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime       (1992,12,2),Gender=EnumGender.Erkek,  UserType=(EnumUserType) 2, UserName="m.arslan", NormalizedUserName="MARSLAN", Email= "mustafa.arslan@gmail.com", NormalizedEmail="MUSTAFA.ARSLAN@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5", FirstName="Gizem", LastName="Aksoy",NormalizedName="GIZEMAKSOY", Url="gizem-aksoy", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1996,5,21),Gender=EnumGender.Kadın, UserType=(EnumUserType) 2, UserName="gizem.aksoy", NormalizedUserName="GIZEMAKSOY", Email= "g.aksoy@hotmail.com", NormalizedEmail="G.AKSOY@HOTMAIL.COM", EmailConfirmed=true},

                new User{ Id = "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1", FirstName="Burak", LastName="Güneş",NormalizedName="BURAKGUNES", Url="burak-gunes", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1993,7,8),Gender=EnumGender.Erkek, UserType=(EnumUserType) 2, UserName="burakgunes", NormalizedUserName="BURAKGUNES", Email= "bgunes@outlook.com", NormalizedEmail="BGUNES@OUTLOOK.COM", EmailConfirmed=true},

                new User{ Id = "d10e29b9-9f64-444d-8d0c-7a69e00e13b7", FirstName="Esra", LastName="Gültekin",NormalizedName="ESRAGULTEKIN", Url="esra-gultekin", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1999,2,17),Gender=EnumGender.Kadın, UserType=(EnumUserType) 2, UserName="esra_gultekin", NormalizedUserName="ESRAGULTEKIN", Email= "esra.gultekin@gmail.com", NormalizedEmail="ESRA.GULTEKIN@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "a0d9c91b-3e6c-4528-a31e-58a47be27108", FirstName="Emre", LastName="Öztürk",NormalizedName="EMREOZTURK", Url="emre-ozturk", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1997,12,23),Gender=EnumGender.Erkek, UserType=(EnumUserType) 2, UserName="emre_ozturk", NormalizedUserName="EMREOZTURK", Email= "e.ozturk@hotmail.com", NormalizedEmail="E.OZTURK@HOTMAIL.COM", EmailConfirmed=true},

                new User{ Id = "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd", FirstName="Selin", LastName="Koçak",NormalizedName="SELINKOCAK", Url="selin-kocak", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1994,11,4),Gender=EnumGender.Kadın, UserType=(EnumUserType) 2, UserName="selinkocak", NormalizedUserName="SELINKOCAK", Email= "s.kocak@gmail.com", NormalizedEmail="S.KOCAK@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f", FirstName="Deniz", LastName="Şahin",NormalizedName="DENIZSAHIN", Url="deniz-sahin", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1998,8,13),Gender=EnumGender.Erkek, UserType=(EnumUserType) 2, UserName="deniz.sahin", NormalizedUserName="DENIZSAHIN", Email= "deniz.sahin@yahoo.com", NormalizedEmail="DENIZ.SAHIN@YAHOO.COM", EmailConfirmed=true},

                new User{ Id = "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d", FirstName="Beyza", LastName="Karaca",NormalizedName="BEYZAKARACA", Url="beyza-karaca", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1995,3,27),Gender=EnumGender.Kadın, UserType=(EnumUserType) 2, UserName="beyza.karaca", NormalizedUserName="BEYZAKARACA", Email= "beyzakaraca@gmail.com", NormalizedEmail="BEYZAKARACA@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd", FirstName="Yasin", LastName="Kılıç",NormalizedName="YASINKILIC", Url="yasin-kilic", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1992,6,18),Gender=EnumGender.Erkek, UserType=(EnumUserType) 2, UserName="yasin.kilic", NormalizedUserName="YASINKILIC", Email= "yasin.kilic@hotmail.com", NormalizedEmail="YASIN.KILIC@HOTMAIL.COM", EmailConfirmed=true},

                new User{ Id = "8a55c638-baff-413a-bdb9-b9b41f768b71", FirstName="Zeynep", LastName="Yılmaz",NormalizedName="ZEYNEPYILMAZ", Url="zeynep-yilmaz", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1996,9,5),Gender=EnumGender.Kadın, UserType=(EnumUserType) 2, UserName="zeynep.yilmaz", NormalizedUserName="ZEYNEPYILMAZ", Email= "z.yilmaz@gmail.com", NormalizedEmail="Z.YILMAZ@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad", FirstName="Serdar", LastName="Kara",NormalizedName="SERDARKARA", Url="serdar-kara", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1994,2,11),Gender=EnumGender.Erkek, UserType=(EnumUserType) 2, UserName="serdarkara", NormalizedUserName="SERDARKARA", Email= "serdar.kara@yahoo.com", NormalizedEmail="SERDAR.KARA@YAHOO.COM", EmailConfirmed=true},

                new User{ Id = "cc95335c-9a83-4a22-8f8e-b083dd6fc663", FirstName="Ayşe", LastName="Aydın",NormalizedName="AYSEAYDIN", Url="ayse-aydin", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(1997,12,3),Gender=EnumGender.Kadın, UserType=(EnumUserType) 2, UserName="ayseaydin", NormalizedUserName="AYSEAYDIN", Email= "ayseaydin@gmail.com", NormalizedEmail="AYSEAYDIN@GMAIL.COM", EmailConfirmed=true},

                new User{ Id = "a176cd80-4d75-47a8-b51a-6d059790bfe7", FirstName="Sefa", LastName="Öztürk",NormalizedName="SEFAOZTURK", Url="sefa-ozturk", CreatedDate=DateTime.Now, UpdatedDate =DateTime.Now, BirthDate=new DateTime(2001,5,22),Gender=EnumGender.Erkek, UserType=(EnumUserType) 1, UserName="sefaozturk", NormalizedUserName="SEFAOZTURK", Email= "sefaozturk@gmail.com", NormalizedEmail="SEFAOZTURK@GMAIL.COM", EmailConfirmed=true}

            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Student Oluşturma
            List<Student> students = new List<Student>
            {
                new Student {Id=1, UserId= "a176cd80-4d75-47a8-b51a-6d059790bfe7", ImageUrl="sefa-ozturk.jpg" }
            };
            modelBuilder.Entity<Student>().HasData(students);
            #endregion
            #region Teacher Oluşturma
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher {Id=1, UserId = "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7", AboutId = 1, Title = "Matematik Öğretmeni", IsApproved = true, ImageUrl = "ali-yilmaz.jpg" },
                new Teacher {Id=2, UserId = "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10", AboutId = 2, Title = "Edebiyat Öğretmeni", IsApproved = true, ImageUrl = "ayse-demir.jpg" },
                new Teacher {Id=3, UserId = "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4", AboutId = 3, Title = "İngilizce Öğretmeni", IsApproved = true, ImageUrl = "mehmet-kaya.jpg" },
                new Teacher {Id=4, UserId = "a17a2a35-1b72-42af-8d68-0b55faa60f22", AboutId = 4, Title = "Matematik Öğretmeni", IsApproved = true, ImageUrl = "elif-sahin.jpg" },
                new Teacher {Id = 5,  UserId = "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2", AboutId = 5, Title = "Türkçe Öğretmeni", IsApproved = true, ImageUrl = "mustafa-arslan.jpg" },
                new Teacher {Id = 6,  UserId = "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5", AboutId = 6, Title = "Müzik Öğretmeni", IsApproved = true, ImageUrl = "gizem-aksoy.jpg" },
                new Teacher {Id = 7,  UserId = "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1", AboutId = 7, Title = "Edebiyat Öğretmeni", IsApproved = true, ImageUrl = "burak-gunes.jpg" },
                new Teacher {Id=8, UserId = "d10e29b9-9f64-444d-8d0c-7a69e00e13b7", AboutId = 8, Title = "İngilizce Öğretmeni", IsApproved = true, ImageUrl = "esra-gultekin.jpg" },
                new Teacher {Id = 9,  UserId = "a0d9c91b-3e6c-4528-a31e-58a47be27108", AboutId = 9, Title = "Fen Bilimleri Öğretmeni", IsApproved = true, ImageUrl = "emre-ozturk.jpg" },
                new Teacher {Id = 10,  UserId = "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd", AboutId = 10, Title = "Sosyal Bilimler Öğretmeni", IsApproved = true, ImageUrl = "selin-kocak.jpg" },
                new Teacher {Id = 11,  UserId = "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f", AboutId = 11, Title = "Psikoloji Öğretmeni", IsApproved = true, ImageUrl = "deniz-sahin.jpg" },
                new Teacher {Id = 12,  UserId = "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d", AboutId = 12, Title = "Müzik Öğretmeni", IsApproved = true, ImageUrl = "beyza-karaca.jpg" },
                new Teacher {Id = 13,  UserId = "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd", AboutId = 13, Title = "Biyoloji Öğretmeni", IsApproved = true, ImageUrl = "yasin-kilic.jpg" },
                new Teacher {Id = 14,  UserId = "8a55c638-baff-413a-bdb9-b9b41f768b71", AboutId = 14, Title = "Kimya Öğretmeni", IsApproved = true, ImageUrl = "zeynep-yilmaz.jpg" },
                new Teacher {Id = 15,  UserId = "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad", AboutId = 15, Title = "Fizik Öğretmeni", IsApproved = true, ImageUrl = "serdar-kara.jpg" },
                new Teacher {Id = 16,  UserId = "cc95335c-9a83-4a22-8f8e-b083dd6fc663", AboutId = 16, Title = "Kimya Öğretmeni", IsApproved = true, ImageUrl = "ayse-aydin.jpg" }
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);
            #endregion
            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");
            users[4].PasswordHash = passwordHasher.HashPassword(users[4], "Qwe123.");
            users[5].PasswordHash = passwordHasher.HashPassword(users[5], "Qwe123.");
            users[6].PasswordHash = passwordHasher.HashPassword(users[6], "Qwe123.");
            users[7].PasswordHash = passwordHasher.HashPassword(users[7], "Qwe123.");
            users[8].PasswordHash = passwordHasher.HashPassword(users[8], "Qwe123.");
            users[9].PasswordHash = passwordHasher.HashPassword(users[9], "Qwe123.");
            users[10].PasswordHash = passwordHasher.HashPassword(users[10], "Qwe123.");
            users[11].PasswordHash = passwordHasher.HashPassword(users[11], "Qwe123.");
            users[12].PasswordHash = passwordHasher.HashPassword(users[12], "Qwe123.");
            users[13].PasswordHash = passwordHasher.HashPassword(users[13], "Qwe123.");
            users[14].PasswordHash = passwordHasher.HashPassword(users[14], "Qwe123.");
            users[15].PasswordHash = passwordHasher.HashPassword(users[15], "Qwe123.");
            users[16].PasswordHash = passwordHasher.HashPassword(users[16], "Qwe123.");
            users[17].PasswordHash = passwordHasher.HashPassword(users[17], "Qwe123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id},
                new IdentityUserRole<string>{ UserId=users[1].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[2].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[3].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[4].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[5].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[6].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[7].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[8].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[9].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[10].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[11].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[12].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[13].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[14].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[15].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[16].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id},
                new IdentityUserRole<string>{ UserId=users[17].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id}
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
        }
    }
}
