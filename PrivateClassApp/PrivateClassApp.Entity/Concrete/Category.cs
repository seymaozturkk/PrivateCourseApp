using PrivateClassApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class Category : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public List<LessonCategory> LessonCategories { get; set; }

    }
}
