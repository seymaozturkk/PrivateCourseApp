using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Areas.Admin.Models.ViewModels;

namespace PrivateClassApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReservationService _reservationService;
        private readonly ILessonService _lessonService;

        public HomeController(UserManager<User> userManager, IReservationService reservationService, ILessonService lessonService)
        {
            _userManager = userManager;
            _reservationService = reservationService;
            _lessonService = lessonService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var users = await _userManager.GetUsersInRoleAsync("User");
            var reservations = await _reservationService.GetAllAsync();
            var lessons = await _lessonService.GetAllFullDataAsync(null);
            var reservationsModel = reservations.Select(x => new ReservationModel
            {
                Id = x.Id,
                Lesson = lessons.Where(l => l.Id == x.LessonId).Select(x => new LessonViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Teacher = x.Teacher,
                }).FirstOrDefault(),
                ReservationDate = x.ReservationDate,
                UserId = x.UserId,
                ZoomLink = x.ZoomLink,
                ReservationUser = users.Where(u => u.Id == x.UserId).FirstOrDefault(),
            }).ToList();
            ViewBag.TodayUsers = users.Where(u => u.UpdatedDate.ToShortDateString() == DateTime.Now.ToShortDateString()).ToList().Count;
            ViewBag.NewUsers = users.Where(u => u.CreatedDate.ToShortDateString() == DateTime.Now.ToShortDateString()).ToList().Count;
            return View(reservationsModel);
        }
    }
}
