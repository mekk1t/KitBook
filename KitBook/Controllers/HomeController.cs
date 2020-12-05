using Microsoft.AspNetCore.Mvc;

namespace KitBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => RedirectToActionPermanent("GetRecipes", "Recipe");

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => null;
    }
}
