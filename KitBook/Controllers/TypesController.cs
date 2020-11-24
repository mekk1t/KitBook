using System;
using System.Linq;
using BusinessLogic.Interfaces;
using BusinessLogic.Models.Types.Interface;
using KitBook.Mappers.Interfaces;
using KitBook.Models.Database.Entities.Types;
using KitBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KitBook.Controllers
{
    public class TypesController : Controller
    {
        private readonly IRepositoryAdvanced<RecipeType> recipeTypeRepository;
        private readonly IRepositoryAdvanced<DishType> dishTypeRepository;
        private readonly IRepositoryAdvanced<CookingType> cookingTypeRepository;
        private readonly IRepositoryAdvanced<IngredientType> ingredientTypeRepository;
        private readonly ITypeMapper mapper;

        private const string GET = "GET";
        private const string POST = "POST";
        private const string PUT = "PUT";
        private const string GET_LIST = "GET_LIST";

        // ЗДЕСЬ НУЖНО ИСПОЛЬЗОВАТЬ AJAX, ТК ОПЕРАЦИИ НЕЗНАЧИТЕЛЬНЫЕ и могут пригодиться при редактировании / создании
        public TypesController(
            IRepositoryAdvanced<RecipeType> recipeTypeRepository,
            IRepositoryAdvanced<CookingType> cookingTypeRepository,
            IRepositoryAdvanced<IngredientType> ingredientTypeRepository,
            IRepositoryAdvanced<DishType> dishTypeRepository,
            ITypeMapper mapper)
        {
            this.mapper = mapper;
            this.recipeTypeRepository = recipeTypeRepository;
            this.cookingTypeRepository = cookingTypeRepository;
            this.dishTypeRepository = dishTypeRepository;
            this.ingredientTypeRepository = ingredientTypeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region RecipeType
        [HttpGet]
        public IActionResult GetRecipeTypes()
        {
            var viewModel = recipeTypeRepository.GetListWithRelationships().Select(rt => mapper.Map(rt));
            return View(GET_LIST, viewModel);
        }

        [HttpGet]
        public IActionResult GetRecipeType(Guid id)
        {
            var viewModel = mapper.Map(recipeTypeRepository.GetByIdWithRelationships(id));
            return View(GET, viewModel);
        }

        [HttpPost]
        public IActionResult PostRecipeType(RecipeType type)
        {
            recipeTypeRepository.Create(type);
            return RedirectToAction(nameof(GetRecipeTypes));
        }

        [HttpGet]
        public IActionResult PostRecipeType()
        {
            var viewModel = GeneratePostViewModel<RecipeType>();
            return View(POST, viewModel);
        }

        [HttpPost]
        public IActionResult PutRecipeType(TypeViewModel viewModel)
        {
            var type = mapper.Map<RecipeType>(viewModel);
            recipeTypeRepository.Update(type);
            return RedirectToAction(nameof(GetRecipeType), new { id = type.Id });
        }

        [HttpGet]
        public IActionResult PutRecipeType(Guid id)
        {
            var type = recipeTypeRepository.GetById(id);
            var viewModel = mapper.Map(type);
            return View(PUT, viewModel);
        }

        public IActionResult DeleteRecipeType(Guid id)
        {
            recipeTypeRepository.DeleteById(id);
            return RedirectToAction(nameof(GetRecipeTypes));
        }
        #endregion

        #region CookingType
        [HttpGet]
        public IActionResult GetCookingTypes()
        {
            var viewModel = cookingTypeRepository.GetListWithRelationships().Select(ct => mapper.Map(ct));
            return View(GET_LIST, viewModel);
        }

        [HttpGet]
        public IActionResult GetCookingType(Guid id)
        {
            var viewModel = mapper.Map(cookingTypeRepository.GetByIdWithRelationships(id));
            return View(GET, viewModel);
        }

        [HttpPost]
        public IActionResult PostCookingType(CookingType type)
        {
            cookingTypeRepository.Create(type);
            return RedirectToAction(nameof(GetCookingTypes));
        }

        [HttpGet]
        public IActionResult PostCookingType()
        {
            var viewModel = GeneratePostViewModel<CookingType>();
            return View(POST, viewModel);
        }

        [HttpPost]
        public IActionResult PutCookingType(TypeViewModel viewModel)
        {
            var type = mapper.Map<CookingType>(viewModel);
            cookingTypeRepository.Update(type);
            return RedirectToAction(nameof(GetCookingType), new { id = type.Id });
        }

        [HttpGet]
        public IActionResult PutCookingType(Guid id)
        {
            var type = cookingTypeRepository.GetById(id);
            var viewModel = mapper.Map(type);
            return View(PUT, viewModel);
        }

        public IActionResult DeleteCookingType(Guid id)
        {
            cookingTypeRepository.DeleteById(id);
            return RedirectToAction(nameof(GetCookingTypes));
        }
        #endregion

        #region DishType
        [HttpGet]
        public IActionResult GetDishTypes()
        {
            var viewModel = dishTypeRepository.GetListWithRelationships().Select(dt => mapper.Map(dt));
            return View(GET_LIST, viewModel);
        }

        [HttpGet]
        public IActionResult GetDishType(Guid id)
        {
            var viewModel = mapper.Map(dishTypeRepository.GetByIdWithRelationships(id));
            return View(GET, viewModel);
        }

        [HttpPost]
        public IActionResult PostDishType(DishType type)
        {
            dishTypeRepository.Create(type);
            return RedirectToAction(nameof(GetDishTypes));
        }

        [HttpGet]
        public IActionResult PostDishType()
        {
            var viewModel = GeneratePostViewModel<DishType>();
            return View(POST, viewModel);
        }

        [HttpPost]
        public IActionResult PutDishType(TypeViewModel viewModel)
        {
            var type = mapper.Map<DishType>(viewModel);
            dishTypeRepository.Update(type);
            return RedirectToAction(nameof(GetDishType), new { id = type.Id });
        }

        [HttpGet]
        public IActionResult PutDishType(Guid id)
        {
            var type = dishTypeRepository.GetById(id);
            var viewModel = mapper.Map(type);
            return View(PUT, viewModel);
        }

        public IActionResult DeleteDishType(Guid id)
        {
            dishTypeRepository.DeleteById(id);
            return RedirectToAction(nameof(GetDishTypes));
        }
        #endregion

        #region IngredientType
        [HttpGet]
        public IActionResult GetIngredientTypes()
        {
            var viewModel = ingredientTypeRepository.GetListWithRelationships().Select(it => mapper.Map(it));
            return View(GET_LIST, viewModel);
        }

        [HttpGet]
        public IActionResult GetIngredientType(Guid id)
        {
            var viewModel = mapper.Map(ingredientTypeRepository.GetByIdWithRelationships(id));
            return View(GET, viewModel);
        }

        [HttpPost]
        public IActionResult PostIngredientType(TypeViewModel viewModel)
        {
            var type = mapper.Map<IngredientType>(viewModel);
            ingredientTypeRepository.Create(type);
            return RedirectToAction(nameof(GetIngredientTypes));
        }

        [HttpGet]
        public IActionResult PostIngredientType()
        {
            var viewModel = GeneratePostViewModel<IngredientType>();
            return View(POST, viewModel);
        }

        [HttpPost]
        public IActionResult PutIngredientType(TypeViewModel viewModel)
        {
            var type = mapper.Map<IngredientType>(viewModel);
            ingredientTypeRepository.Update(type);
            return RedirectToAction(nameof(GetIngredientType), new { id = type.Id });
        }

        [HttpGet]
        public IActionResult PutIngredientType(Guid id)
        {
            var type = ingredientTypeRepository.GetById(id);
            var viewModel = mapper.Map(type);
            return View(PUT, viewModel);
        }

        public IActionResult DeleteIngredientType(Guid id)
        {
            ingredientTypeRepository.DeleteById(id);
            return RedirectToAction(nameof(GetIngredientTypes));
        }
        #endregion

        private TypeViewModel GeneratePostViewModel<T>()
            where T: IType
        {
            return new TypeViewModel
            {
                KindOfType = typeof(T).Name
            };
        }
    }
}
