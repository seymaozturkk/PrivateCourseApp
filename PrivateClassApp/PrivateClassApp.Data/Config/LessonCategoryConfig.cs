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
    public class LessonCategoryConfig : IEntityTypeConfiguration<LessonCategory>
    {
        public void Configure(EntityTypeBuilder<LessonCategory> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.CategoryId });
            builder.HasData(
                new LessonCategory { LessonId=1, CategoryId=2 },
                new LessonCategory { LessonId = 2, CategoryId = 1 },
                new LessonCategory { LessonId = 3, CategoryId = 9 },
                new LessonCategory { LessonId = 4, CategoryId = 2 },
                new LessonCategory { LessonId = 5, CategoryId = 5 },
                new LessonCategory { LessonId = 6, CategoryId = 4 },
                new LessonCategory { LessonId = 7, CategoryId = 1 },
                new LessonCategory { LessonId = 8, CategoryId = 9 },
                new LessonCategory { LessonId = 9, CategoryId = 10 },
                new LessonCategory { LessonId = 10, CategoryId = 11 },
                new LessonCategory { LessonId = 11, CategoryId = 12 },
                new LessonCategory { LessonId = 12, CategoryId = 4 },
                new LessonCategory { LessonId = 13, CategoryId = 7 },
                new LessonCategory { LessonId = 14, CategoryId = 6 },
                new LessonCategory { LessonId = 15, CategoryId = 8 },
                new LessonCategory { LessonId = 16, CategoryId = 6 }
            );
        }
    }
}
