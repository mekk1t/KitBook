using KK.Cookbook.Models.ViewData;
using Microsoft.AspNetCore.Mvc;

namespace KK.Cookbook.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult GetAllRecipes()
        {
            return View("AllRecipes");
        }

        public IActionResult GetRecipeById()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNewRecipe()
        {
            return View("NewRecipe");
        }

        [HttpPost]
        public void CreateNewRecipe([FromForm] RecipeViewData newRecipe)
        {

        }
    }
}
