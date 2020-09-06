using KK.Cookbook.Models.Commands.Interfaces;
using KK.Cookbook.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KK.Cookbook.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult GetAllRecipes([FromServices] IGetAllRecipesCommand command)
        {
            return View("AllRecipes", command.Execute());
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
        public void CreateNewRecipe(
            [FromServices] ICreateNewRecipeCommand command,
            RecipeDto newRecipe)
        {
            var result = command.Execute(newRecipe);
            RedirectToAction(nameof(GetAllRecipes));
            // RedirectToAction("GetRecipeById", result);
        }
    }
}
