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
    public class UniversityEducationConfig : IEntityTypeConfiguration<UniversityEducation>
    {
        public void Configure(EntityTypeBuilder<UniversityEducation> builder)
        {
            builder.HasKey(ue => new { ue.UniversityId, ue.EducationId });
            builder.HasData(
                new UniversityEducation { EducationId=1, UniversityId=1, Description="Lisans Eğitimi"},
                new UniversityEducation { EducationId=2, UniversityId=50, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=3, UniversityId=2, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=4, UniversityId=2, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=5, UniversityId=5, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=6, UniversityId=11, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=7, UniversityId=5, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=8, UniversityId=33, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=9, UniversityId=75, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=10, UniversityId=61, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=11, UniversityId=14, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=12, UniversityId=63, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=13, UniversityId=38, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=14, UniversityId=35, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=15, UniversityId=34, Description = "Lisans Eğitimi" },
                new UniversityEducation { EducationId=16, UniversityId=40, Description = "Lisans Eğitimi" }
            );
        }
    }
}
