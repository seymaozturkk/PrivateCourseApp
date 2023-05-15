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
    public class LessonLikeConfig : IEntityTypeConfiguration<LessonLike>
    {
        public void Configure(EntityTypeBuilder<LessonLike> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.UserId });
        }
    }
}
