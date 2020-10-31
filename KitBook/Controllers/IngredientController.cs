using System;
using KitBook.Models.Database.Entities;
using KitBook.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KitBook.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IRepositoryAdvanced<Ingredient> repository;

        public IngredientController(IRepositoryAdvanced<Ingredient> repository)
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

        [HttpGet]
        public IActionResult PostIngredient()
        {
            return View(nameof(PostIngredient));
        }

        [HttpPost]
        public IActionResult PostIngredient(Ingredient ingredient)
        {
            repository.Create(ingredient);
            return RedirectToAction(nameof(GetIngredient), ingredient.Id);
        }

        [HttpGet]
        public IActionResult PutIngredient()
        {
            return View(nameof(PutIngredient));
        }

        [HttpPost]
        public IActionResult PutIngredient(Ingredient ingredient)
        {
            repository.Update(ingredient);
            return RedirectToAction(nameof(GetIngredients));
        }

        public void DeleteIngredient(Guid id)
        {
            repository.Delete(id);
            RedirectToAction(nameof(GetIngredients));
        }
    }
}
