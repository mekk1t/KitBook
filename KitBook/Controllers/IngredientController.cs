using System;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.DTO;
using KitBook.Models.Repositories.Interfaces;
using KitBook.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitBook.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService service;
        private readonly IRepository<IngredientType> ingredientTypeRepository;

        public IngredientController(IIngredientService service, IRepository<IngredientType> ingredientTypeRepository)
        {
            this.service = service;
            this.ingredientTypeRepository = ingredientTypeRepository;
        }

        private void FillViewBagWithIngredientTypes()
        {
            ViewBag.IngredientTypes = new SelectList(ingredientTypeRepository.Read(), "Id", "Name");
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
            return View(nameof(PostIngredient));
        }

        [HttpPost]
        public IActionResult PostIngredient(IngredientDto dto)
        {
            service.CreateNewIngredient(dto);
            return RedirectToAction(nameof(GetIngredient), new { id = dto.Id });
        }

        [HttpGet]
        public IActionResult PutIngredient()
        {
            return View(nameof(PutIngredient));
        }

        [HttpPost]
        public IActionResult PutIngredient(IngredientDto dto)
        {
            service.UpdateIngredient(dto);
            return RedirectToAction(nameof(GetIngredients));
        }

        public void DeleteIngredient(Guid id)
        {
            service.DeleteIngredientById(id);
            RedirectToAction(nameof(GetIngredients));
        }
    }
}
