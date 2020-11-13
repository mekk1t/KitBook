using System;
using KitBook.Models.Database.Entities;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.DTO;
using KitBook.Models.Repositories.Interfaces;
using KitBook.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService service;
        private readonly IRepository<RecipeType> recipeTypeRepository;
        private readonly IRepository<CookingType> cookingTypeRepository;
        private readonly IRepository<DishType> dishTypeRepository;
        private readonly IRepository<IngredientType> ingredientTypeRepository;
        private readonly IRepositoryAdvanced<Ingredient> ingredientRepository;

        public RecipeController(
            IRecipeService service,
            IRepository<RecipeType> recipeTypeRepository,
            IRepository<CookingType> cookingTypeRepository,
            IRepository<IngredientType> ingredientTypeRepository,
            IRepository<DishType> dishTypeRepository,
            IRepositoryAdvanced<Ingredient> ingredientRepository)
        {
            this.service = service;
            this.recipeTypeRepository = recipeTypeRepository;
            this.cookingTypeRepository = cookingTypeRepository;
            this.dishTypeRepository = dishTypeRepository;
            this.ingredientTypeRepository = ingredientTypeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        private void FillViewBagWithTypes()
        {
            ViewBag.RecipeTypes = new SelectList(recipeTypeRepository.Read(), "Id", "Name");
            ViewBag.CookingTypes = new SelectList(cookingTypeRepository.Read(), "Id", "Name");
            ViewBag.DishTypes = new SelectList(dishTypeRepository.Read(), "Id", "Name");
            ViewBag.IngredientTypes = new SelectList(ingredientTypeRepository.Read(), "Id", "Name");
        }

        private void FillViewBagWithIngredients()
        {
            ViewBag.Ingredients = new SelectList(ingredientRepository.Read(), "Id", "Name");
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            return View(nameof(GetRecipes), service.GetRecipes());
        }

        [HttpGet]
        public IActionResult GetRecipe(Guid id)
        {
            return View(nameof(GetRecipe), service.GetRecipeById(id));
        }

        [HttpPost]
        public IActionResult PostRecipe(RecipeDto dto)
        {
            service.CreateNewRecipe(dto);
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
        public IActionResult PutRecipe(RecipeDto dto)
        {
            service.UpdateRecipe(dto);
            return RedirectToAction(nameof(GetRecipe), new { id = dto.Id });
        }

        [HttpGet]
        public IActionResult PutRecipe(Guid id)
        {
            FillViewBagWithTypes();
            FillViewBagWithIngredients();
            var formData = service.GetRecipeById(id);
            return View(nameof(PutRecipe), formData);
        }

        public IActionResult DeleteRecipe(Guid id)
        {
            service.DeleteRecipeById(id);
            return RedirectToAction(nameof(GetRecipes));
        }
    }
}
