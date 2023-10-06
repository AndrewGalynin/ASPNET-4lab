using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Lab_4.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IConfiguration _configuration;

        public LibraryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return Content("Привіт, ласкаво просимо до бібліотеки!");
        }

        public IActionResult Books()
        {
            var books = _configuration.GetSection("Books").Get<string[]>();
            return View(books);
        }

        public IActionResult Profile(int? id) 
        {
            if (id.HasValue && id >= 0 && id <= 5)
            {
                var userProfile = _configuration.GetSection($"Profiles:{id}").Get<string[]>();
                return Content($"Інформація про користувача №{id}: {userProfile}");
            }

            var defaultProfile = _configuration.GetSection("DefaultProfile").Get<string>();
            return Content($"Інформація про вас: {defaultProfile}");
        }
    }
}
