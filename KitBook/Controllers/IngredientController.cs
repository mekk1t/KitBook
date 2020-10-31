using System;
using KitBook.Models.Database.Entities;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KitBook.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IRepository<Ingredient> repository;

        public IngredientController(IRepository<Ingredient> repository)
        {
            this.repository = repository;
        }

        public IActionResult GetIngredient(Guid id)
        {
            return View(nameof(GetIngredient), repository.Read(id));
        }

        public IActionResult GetIngredients()
        {
            return View(nameof(GetIngredients), repository.Read());
        }

        public IActionResult PostIngredientForm()
        {
            return View(nameof(PostIngredientForm));
        }

        public void PostIngredient(Ingredient ingredient)
        {
            repository.Create(ingredient);
            RedirectToAction(nameof(GetIngredient), ingredient.Id);
        }

        public IActionResult PutIngredientForm()
        {
            return View(nameof(PutIngredientForm));
        }

        public void PutIngredient(Ingredient ingredient)
        {
            repository.Update(ingredient);
            RedirectToAction(nameof(GetIngredients));
        }

        public void DeleteIngredient(Guid id)
        {
            repository.Delete(id);
            RedirectToAction(nameof(GetIngredients));
        }
    }
}
