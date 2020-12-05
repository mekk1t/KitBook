using System;
using System.Linq;
using BusinessLogic.Interfaces;
using KitBook.Handlers.Interfaces;
using KitBook.Mappers.Interfaces;
using KitBook.Models.Database.Entities;
using KitBook.Models.Services.Interfaces;
using KitBook.Models.ViewModels.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeMapper mapper;
        private readonly IRecipeService service;
        private readonly ITypeHandler typeHandler;
        private readonly IRepositoryAdvanced<Ingredient> ingredientRepository;

        public RecipeController(
            IRecipeMapper mapper,
            IRecipeService service,
            ITypeHandler typeHandler,
            IRepositoryAdvanced<Ingredient> ingredientRepository)
        {
            this.mapper = mapper;
            this.service = service;
            this.typeHandler = typeHandler;
            this.ingredientRepository = ingredientRepository;
        }

        private void FillViewBagWithTypes()
        {
            ViewBag.RecipeTypes = new SelectList(typeHandler.GetRecipeTypes().OrderBy(t => t.Name), "Id", "Name");
            ViewBag.CookingTypes = new SelectList(typeHandler.GetCookingTypes().OrderBy(t => t.Name), "Id", "Name");
            ViewBag.DishTypes = new SelectList(typeHandler.GetDishTypes().OrderBy(t => t.Name), "Id", "Name");
            ViewBag.IngredientTypes = new SelectList(typeHandler.GetIngredientTypes().OrderBy(t => t.Name), "Id", "Name");
        }

        private void FillViewBagWithIngredients()
        {
            ViewBag.Ingredients = new SelectList(ingredientRepository.GetList().OrderBy(t => t.Name), "Id", "Name");
        }

        public IActionResult GetRecipesAdmin()
        {
            var recipes = service.GetRecipes();
            var viewModel = recipes.Select(r => mapper.Map(r));
            return View(nameof(GetRecipesAdmin), viewModel);
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            var recipes = service.GetRecipes();
            var viewModel = recipes.Select(r => mapper.Map(r));
            return View(nameof(GetRecipes), viewModel);
        }

        [HttpGet]
        public IActionResult GetRecipe(Guid id)
        {
            var recipe = service.GetRecipeById(id);
            var viewModel = mapper.Map(recipe);
            return View(nameof(GetRecipe), viewModel);
        }

        [HttpPost]
        public IActionResult PostRecipe(NewRecipe model)
        {
            var recipe = mapper.Map(model);
            service.CreateNewRecipe(recipe);
            return RedirectToAction(nameof(GetRecipes));
        }

        [HttpGet]
        public IActionResult PostRecipe()
        {
            FillViewBagWithTypes();
            FillViewBagWithIngredients();
            return View(nameof(PostRecipe));
        }

        [HttpPost]
        public IActionResult PutRecipe(EditRecipe model)
        {
            var recipe = mapper.Map(model);
            service.UpdateRecipe(recipe);
            return RedirectToAction(nameof(GetRecipe), new { id = model.Id });
        }

        [HttpGet]
        public IActionResult PutRecipe(Guid id)
        {
            FillViewBagWithTypes();
            FillViewBagWithIngredients();
            var recipe = service.GetRecipeById(id);
            var viewModel = mapper.MapToEdit(recipe);
            return View(nameof(PutRecipe), viewModel);
        }

        public IActionResult DeleteRecipe(Guid id)
        {
            service.DeleteRecipeById(id);
            return RedirectToAction(nameof(GetRecipes));
        }
    }
}
