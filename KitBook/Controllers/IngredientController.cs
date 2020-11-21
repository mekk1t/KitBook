using System;
using BusinessLogic.Interfaces;
using KitBook.Mappers.Interfaces;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.Services.Interfaces;
using KitBook.Models.ViewModels.Ingredient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitBook.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientMapper mapper;
        private readonly IIngredientService service;
        private readonly IRepository<IngredientType> ingredientTypeRepository;

        public IngredientController(
            IIngredientService service,
            IIngredientMapper mapper,
            IRepository<IngredientType> ingredientTypeRepository)
        {
            this.service = service;
            this.ingredientTypeRepository = ingredientTypeRepository;
        }

        private void FillViewBagWithIngredientTypes()
        {
            ViewBag.IngredientTypes = new SelectList(ingredientTypeRepository.GetList(), "Id", "Name");
        }

        public IActionResult GetIngredient(Guid id)
        {
            return View(nameof(GetIngredient), service.GetIngredientById(id));
        }

        public IActionResult GetIngredients()
        {
            return View(nameof(GetIngredients), service.GetIngredients());
        }

        [HttpGet]
        public IActionResult PostIngredient()
        {
            FillViewBagWithIngredientTypes();
            return View(nameof(PostIngredient));
        }

        [HttpPost]
        public IActionResult PostIngredient(IngredientViewModel viewModel)
        {
            var ingredient = mapper.Map(viewModel);
            service.CreateNewIngredient(ingredient);
            return RedirectToAction(nameof(GetIngredient), new { id = viewModel.Id });
        }

        [HttpGet]
        public IActionResult PutIngredient(Guid id)
        {
            FillViewBagWithIngredientTypes();
            return View(nameof(PutIngredient), service.GetIngredientById(id));
        }

        [HttpPost]
        public IActionResult PutIngredient(IngredientViewModel viewModel)
        {
            var ingredient = mapper.Map(viewModel);
            service.UpdateIngredient(ingredient);
            return RedirectToAction(nameof(GetIngredients));
        }

        public void DeleteIngredient(Guid id)
        {
            service.DeleteIngredientById(id);
            RedirectToAction(nameof(GetIngredients));
        }

        [HttpGet]
        public string IngredientsSelectList()
        {
            return PopulateSelectListWithIngredients();
        }

        private string PopulateSelectListWithIngredients()
        {
            string options = "";
            var ingredients = service.GetIngredients();
            foreach (var ingredient in ingredients)
            {
                options += $"<option value=\"{ingredient.Id}\">{ingredient.Name}</option>";
            }

            return options;
        }
    }
}
