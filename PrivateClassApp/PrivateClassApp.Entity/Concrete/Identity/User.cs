using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete.Identity
{
    public class User : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        public EnumGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public EnumUserType UserType { get; set; }

    }

    public enum EnumUserType
    {
        Admin=0, Öğrenci=1, Öğretmen=2
    }
    public enum EnumGender
    {
        Erkek, Kadın
    }
}
