using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<LikedItem> LikedItems { get; set; }
    }
}
