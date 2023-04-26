using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PrivateClassApp.MVC.Areas.Admin.Models.ViewModels
{
	public class UserManageViewModel
	{
        public string Id { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public EnumUserType UserType { get; set; }
	}
}
