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
        private readonly IRepository<Recipe> repository;
        private readonly IRepository<RecipeType> recipeTypeRepository;
        private readonly IRepository<CookingType> cookingTypeRepository;
        private readonly IRepository<DishType> dishTypeRepository;
        private readonly IRepository<IngredientType> ingredientTypeRepository;

        public RecipeController(
            IRepository<Recipe> repository,
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

        public IActionResult GetRecipes()
        {
            return View(nameof(GetRecipes), repository.Read());
        }

        public IActionResult GetRecipe(Guid id)
        {
            return View(nameof(GetRecipe), repository.Read(id));
        }

        public void PostRecipe(Recipe entity)
        {
            repository.Create(entity);
            RedirectToAction(nameof(GetRecipes));
        }

        public IActionResult PostRecipeForm()
        {
            FillViewBagWithTypes();
            return View(nameof(PostRecipeForm));
        }

        public void PutRecipe(Recipe entity)
        {
            repository.Update(entity);
            RedirectToAction(nameof(GetRecipe), entity.Id);
        }

        public IActionResult PutRecipeForm(Guid id)
        {
            FillViewBagWithTypes();
            var formData = repository.Read(id);
            return View(nameof(PutRecipeForm), formData);
        }

        public void DeleteRecipe(Guid id)
        {
            repository.Delete(id);
            RedirectToAction(nameof(GetRecipes));
        }
    }
}
