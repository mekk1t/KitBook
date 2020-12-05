using System;
using System.Linq;
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
        private readonly IRepositoryAdvanced<IngredientType> ingredientTypeRepository;

        public IngredientController(
            IIngredientService service,
            IIngredientMapper mapper,
            IRepositoryAdvanced<IngredientType> ingredientTypeRepository)
        {
            this.mapper = mapper;
            this.service = service;
            this.ingredientTypeRepository = ingredientTypeRepository;
        }

        public IActionResult GetIngredient(Guid id)
        {
            var ingredient = service.GetIngredientById(id);
            var viewModel = mapper.Map(ingredient);
            return View(nameof(GetIngredient), viewModel);
        }

        public IActionResult GetIngredientsAdmin()
        {
            var ingredients = service.GetIngredients();
            var viewModel = ingredients.Select(i => mapper.Map(i));
            return View(nameof(GetIngredientsAdmin), viewModel);
        }

        public IActionResult GetIngredients()
        {
            var ingredients = service.GetIngredients();
            var viewModel = ingredients.Select(i => mapper.Map(i));
            return View(nameof(GetIngredients), viewModel);
        }

        [HttpGet]
        public IActionResult PostIngredient()
        {
            FillViewBagWithIngredientTypes();
            return View(nameof(PostIngredient));
        }

        [HttpPost]
        public IActionResult PostIngredient(NewIngredient viewModel)
        {
            var ingredient = mapper.Map(viewModel);
            service.CreateNewIngredient(ingredient);
            return RedirectToAction(nameof(GetIngredient), new { id = ingredient.Id });
        }

        [HttpGet]
        public IActionResult PutIngredient(Guid id)
        {
            var ingredient = service.GetIngredientById(id);
            var viewModel = mapper.MapToEdit(ingredient);
            FillViewBagWithIngredientTypes();
            return View(nameof(PutIngredient), viewModel);
        }

        [HttpPost]
        public IActionResult PutIngredient(EditIngredient viewModel)
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
            var ingredients = service.GetIngredients().OrderBy(i => i.Name);
            foreach (var ingredient in ingredients)
            {
                options += $"<option value=\"{ingredient.Id}\">{ingredient.Name}</option>";
            }

            return options;
        }

        private void FillViewBagWithIngredientTypes()
        {
            ViewBag.IngredientTypes = new SelectList(ingredientTypeRepository.GetList()
                .OrderBy(i => i.Name), "Id", "Name");
        }
    }
}
