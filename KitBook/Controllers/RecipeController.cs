using System;
using KitBook.Models.Database.Entities;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRepositoryAdvanced<Recipe> repository;
        private readonly IRepository<RecipeType> recipeTypeRepository;
        private readonly IRepository<CookingType> cookingTypeRepository;
        private readonly IRepository<DishType> dishTypeRepository;
        private readonly IRepository<IngredientType> ingredientTypeRepository;

        public RecipeController(
            IRepositoryAdvanced<Recipe> repository,
            IRepository<RecipeType> recipeTypeRepository,
            IRepository<CookingType> cookingTypeRepository,
            IRepository<IngredientType> ingredientTypeRepository,
            IRepository<DishType> dishTypeRepository)
        {
            this.repository = repository;
            this.recipeTypeRepository = recipeTypeRepository;
            this.cookingTypeRepository = cookingTypeRepository;
            this.dishTypeRepository = dishTypeRepository;
            this.ingredientTypeRepository = ingredientTypeRepository;
        }

        private void FillViewBagWithTypes()
        {
            ViewBag.RecipeTypes = new SelectList(recipeTypeRepository.Read(), "Id", "Name");
            ViewBag.CookingTypes = new SelectList(cookingTypeRepository.Read(), "Id", "Name");
            ViewBag.DishTypes = new SelectList(dishTypeRepository.Read(), "Id", "Name");
            ViewBag.IngredientTypes = new SelectList(ingredientTypeRepository.Read(), "Id", "Name");
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            return View(nameof(GetRecipes), repository.Read());
        }

        [HttpGet]
        public IActionResult GetRecipe(Guid id)
        {
            return View(nameof(GetRecipe), repository.ReadWithRelationships(id));
        }

        [HttpPost]
        public IActionResult PostRecipe(Recipe entity)
        {
            repository.Create(entity);
            return RedirectToAction(nameof(GetRecipes));
        }

        [HttpGet]
        public IActionResult PostRecipe()
        {
            FillViewBagWithTypes();
            return View(nameof(PostRecipe));
        }

        [HttpPost]
        public IActionResult PutRecipe(Recipe entity)
        {
            repository.Update(entity);
            return RedirectToAction(nameof(GetRecipe), new { id = entity.Id });
        }

        [HttpGet]
        public IActionResult PutRecipe(Guid id)
        {
            FillViewBagWithTypes();
            var formData = repository.Read(id);
            return View(nameof(PutRecipe), formData);
        }

        [HttpDelete]
        public IActionResult DeleteRecipe(Guid id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(GetRecipes));
        }
    }
}
