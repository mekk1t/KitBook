using System;
using KitBook.Models.Database.Entities;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KitBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRepository<Recipe> repository;

        public RecipeController(IRepository<Recipe> repository)
        {
            this.repository = repository;
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
            return View(nameof(PostRecipeForm));
        }

        public void PutRecipe(Recipe entity)
        {
            repository.Update(entity);
            RedirectToAction(nameof(GetRecipe), entity.Id);
        }

        public IActionResult PutRecipeForm(Guid id)
        {
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
