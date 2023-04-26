using PrivateClassApp.Entity.Abstract;
using PrivateClassApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class Student
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
