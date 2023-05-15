using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.EmailServices;
using PrivateClassApp.MVC.Models;

namespace PrivateClassApp.MVC.Controllers
{
    [Authorize]
	public class ReservationsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILessonService _lessonService;
        private readonly ITeacherAvailabilityService _teacherAvailabilityService;
        private readonly ITeacherService _teacherService;
        private readonly IReservationService _reservationService;
        private readonly IEmailSender _emailSender;

        public ReservationsController(ILessonService lessonService, ITeacherAvailabilityService teacherAvailabilityService, ITeacherService teacherService, IReservationService reservationService, UserManager<User> userManager, IEmailSender emailSender)
        {
            _lessonService = lessonService;
            _teacherAvailabilityService = teacherAvailabilityService;
            _teacherService = teacherService;
            _reservationService = reservationService;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index(int id)
        {
            Lesson lesson = await _lessonService.GetByIdAsync(id);
            await _teacherService.GetAllAsync();
            ReservationPageModel model = new ReservationPageModel();
            model.LessonId = lesson.Id;
            model.Teacher = lesson.Teacher;
            model.Price = lesson.Price;
            model.Name = lesson.Name;
            model.Description = lesson.Description;
            model.UpdatedDate = lesson.UpdatedDate;
            model.Availabilities = await _teacherAvailabilityService.GetAvailabilitiesByTeacherIdAsync(lesson.TeacherId);

            return View(model);
        }
        public async Task<IActionResult> ShowTeacherReservations()
        {
            var user = await _userManager.GetUserAsync(User);
            var teacher = await _teacherService.GetTeacherByUserId(user.Id);
            await _userManager.GetUsersInRoleAsync("User");
            var reservations = await _reservationService.GetAllReservationsAsync(user.Id, true);
            var lessons = await _lessonService.GetAllFullDataAsync(null);
            var reservationsModel = reservations.Where(x => x.Lesson.TeacherId == teacher.Id).Select(x => new UserReservationsModel
            {
                Id = x.Id,
                Lesson = lessons.Where(l => l.Id == x.LessonId).Select(x => new LessonModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Teacher = x.Teacher,
                }).FirstOrDefault(),
                ReservationDate = x.ReservationDate,
                UserId = x.UserId,
                ZoomLink = x.ZoomLink
            }).ToList();
            return View(reservationsModel);

        }
        public async Task<IActionResult> ShowMyReservations()
        {
            var user = await _userManager.GetUserAsync(User);
            await _userManager.GetUsersInRoleAsync("User");
            var reservations = await _reservationService.GetAllReservationsAsync(user.Id, true);
            var lessons = await _lessonService.GetAllFullDataAsync(null);
            var reservationsModel = reservations.Select(x => new UserReservationsModel
            {
                Id = x.Id,
                Lesson = lessons.Where(l => l.Id == x.LessonId).Select(x => new LessonModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Teacher = x.Teacher,
                }).FirstOrDefault(),
                ReservationDate = x.ReservationDate,
                UserId = x.UserId,
                ZoomLink = x.ZoomLink
            }).ToList();
            return View(reservationsModel);
            
        }
        public async Task<IActionResult> CancelReservation(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            _reservationService.Delete(reservation);
            return RedirectToAction("ShowMyReservations");
        }
        public async Task<IActionResult> GetReservationTimePartial(DateTime date, int teacherId)
        {
            //model çekilecek. => İlgili teacherId ve date'in day of week değeri için avalibility listesi çekilecek.
            //Bu tarihteki tüm yapılmış rezervasyonları çek. saatlerine bak. IsReserved = true yap o saat alındıysa

            if (date == default)
                return PartialView("_ReservationTimePartial", new List<TeacherAvailabilityModel>());

            var allTeacherAvalibilities = await _teacherAvailabilityService.GetAvailabilitiesByTeacherIdAsync(teacherId);

            var dayEnum = (EnumDay)date.DayOfWeek;

            var availibilitiesByDate = allTeacherAvalibilities.Where(x => x.DayOfWeek == dayEnum).ToList();

            var model = availibilitiesByDate.Select(x => new TeacherAvailabilityModel
            {
                Id = x.Id,
                DayOfWeek = x.DayOfWeek,
                TeacherId = x.TeacherId,
                Time = x.Time,
            }).ToList();

            return PartialView("_ReservationTimePartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut(int availabilityId, int lessonId, DateTime date)
        {
            await _userManager.GetUsersInRoleAsync("User");
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var teacherAvailibility = await _teacherAvailabilityService.GetByIdAsync(availabilityId);
            var lesson = await _lessonService.GetByIdFullDataAsync(lessonId);

            var model = new CheckOutModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ReservationDate = date,
                TeacherAvailabilityModel = new TeacherAvailabilityModel()
                {
                    Id = teacherAvailibility.Id,
                    TeacherId = teacherAvailibility.TeacherId,
                    DayOfWeek = teacherAvailibility.DayOfWeek,
                    Time = teacherAvailibility.Time,
                },
                LessonModel = new LessonModel()
                {
                    Id = lesson.Id,
                    Name = lesson.Name,
                    Description = lesson.Description,
                    Price = lesson.Price,
                    Url = lesson.Url,
                    Teacher = lesson.Teacher,
                    Categories = lesson.LessonCategories.Select(x => x.Category).ToList(),
                    UpdatedDate = lesson.UpdatedDate
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckOutModel checkOutModel)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);

            var teacherAvailibility = await _teacherAvailabilityService.GetByIdAsync(checkOutModel.TeacherAvailabilityModel.Id);

            if (ModelState.IsValid)
            {
                var model = new ReservationModel()
                {
                    UserId = userId,
                    ReservationDate = checkOutModel.ReservationDate.Add(teacherAvailibility.Time),
                    LessonId = checkOutModel.LessonModel.Id,
                    ZoomLink = Jobs.GetZoomLink()
                };

                if (!CardNumberControl(checkOutModel.CardNumber))
                {
                    return View(checkOutModel);
                }

                Payment payment = await PaymentProcess(checkOutModel, userId);
                if (payment.Status == "success")
                    SaveReservation(model);

                //await _emailSender.SendEmailAsync(user.Email, "Özel Ders Zoom Linki", $"Rezervasyonunuza ait dersin Zoom Linki aşağıdadır:<br/>{Jobs.GetZoomLink()}");
                //Outlook kilitlendiği için yorum satırı

                return RedirectToAction("Index", "Home");
            }

            return View(checkOutModel);
        }

        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i += 2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
        }

        [NonAction]
        private async void SaveReservation(ReservationModel reservationModel)
        {
            var reservation = new Reservation()
            {
                UserId = reservationModel.UserId,
                LessonId = reservationModel.LessonId,
                ReservationDate = reservationModel.ReservationDate,
                ZoomLink = reservationModel.ZoomLink
            };

            await _reservationService.CreateAsync(reservation);
            
        }

        private async Task<Payment> PaymentProcess(CheckOutModel checkOutModel, string userId)
        {
            var lesson = await _lessonService.GetByIdAsync(checkOutModel.LessonModel.Id);
            #region Payment Options Created
            Options options = new Options();
            options.ApiKey = "sandbox-4OvwVyzz8670q92DLLrjYaRLXfNxTMoi";
            options.SecretKey = "sandbox-7dRP3jNky2n3ziAFxOs6zt2RK3ArZ5Ya";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            #endregion
            #region Create Payment Request
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = new Random().Next(1000000, 9999999).ToString(),
                Price = Convert.ToInt32(lesson.Price).ToString(),
                PaidPrice = Convert.ToInt32(lesson.Price).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = userId,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName = checkOutModel.CardName,
                    CardNumber = checkOutModel.CardNumber,
                    ExpireMonth = checkOutModel.ExpirationMonth,
                    ExpireYear = checkOutModel.ExpirationYear,
                    Cvc = checkOutModel.Cvc,
                    RegisterCard = 0
                },
                Buyer = new Buyer
                {
                    Id = "BY999",
                    Name = checkOutModel.FirstName,
                    Surname = checkOutModel.LastName,
                    GsmNumber = checkOutModel.Phone,
                    Email = checkOutModel.Email,
                    IdentityNumber = "87955588899",
                    RegistrationAddress = checkOutModel.Address,
                    Ip = "84.99.155.212",
                    City = checkOutModel.City,
                    Country = "Türkiye",
                    ZipCode = "34700"
                },
                ShippingAddress = new Address
                {
                    ContactName = checkOutModel.FirstName + " " + checkOutModel.LastName,
                    City = checkOutModel.City,
                    Country = "Türkiye",
                    Description = checkOutModel.Address
                },
                BillingAddress = new Address
                {
                    ContactName = checkOutModel.FirstName + " " + checkOutModel.LastName,
                    City = checkOutModel.City,
                    Country = "Türkiye",
                    Description = checkOutModel.Address
                }
            };
            request.BasketItems = new List<BasketItem>()
            {
                new BasketItem()
                {
                    Id = userId,
                    Name = userId,
                    Category1 = "Rezervasyon",
                    ItemType = BasketItemType.VIRTUAL.ToString(),
                    Price = Convert.ToInt32(lesson.Price).ToString()
                }
            };
            #endregion
            Payment payment = Payment.Create(request, options);
            return payment;
        }


    }
}
