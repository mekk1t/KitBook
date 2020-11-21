using System;
using System.Linq;
using KitBook.Handlers.Interface;
using KitBook.Mappers.Interfaces;
using KitBook.Models.Database.Entities;
using KitBook.Models.ViewModels;
using KitBook.Models.ViewModels.Recipe;
using Microsoft.AspNetCore.Http;

namespace KitBook.Mappers
{
    public class RecipeMapper : IRecipeMapper
    {
        private readonly IStageMapper stageMapper;
        private readonly IIngredientMapper ingredientMapper;
        private readonly IFileHandler<IFormFile> fileHandler;

        public RecipeMapper(IStageMapper stageMapper, IIngredientMapper ingredientMapper, IFileHandler<IFormFile> fileHandler)
        {
            this.fileHandler = fileHandler;
            this.stageMapper = stageMapper;
            this.ingredientMapper = ingredientMapper;
        }

        public RecipeViewModel Map(Recipe model)
        {
            var viewModel = new RecipeViewModel
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Title = model.Title,
                SourceURL = model.SourceURL,
                CookingTimeMinutes = model.CookingTimeMinutes,
                Stages = model.Stages?.Select(s => stageMapper.Map(s)).ToList(),
                Ingredients = model.Ingredients?.Select(i => ingredientMapper.Map(i)).ToList(),
                DishType = model.DishType?.Name,
                CookingType = model.CookingType?.Name,
                RecipeType = model.RecipeType?.Name
            };

            if (model.Thumbnail != null)
            {
                viewModel.ThumbnailBase64 = Convert.ToBase64String(model.Thumbnail);
                viewModel.ThumbnailContentType = model.ThumbnailContentType;
            };

            return viewModel;
        }

        public Recipe Map(NewRecipe model)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Title = model.Title,
                SourceURL = model.SourceURL,
                CookingTimeMinutes = model.CookingTimeMinutes,
                CookingTypeId = model.CookingTypeId,
                DishTypeId = model.DishTypeId,
                RecipeTypeId = model.RecipeTypeId,
                Stages = model.Stages?.Select(s => stageMapper.Map(s)).ToList(),
                Ingredients = model.Ingredients?.Select(i => ingredientMapper.Map(i))
            };

            if (model.Thumbnail != null)
            {
                GetThumbnail(recipe, model.Thumbnail);
            }
            return recipe;
        }

        public Recipe Map(EditRecipe model)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Title = model.Title,
                SourceURL = model.SourceURL,
                CookingTimeMinutes = model.CookingTimeMinutes,
                CookingTypeId = model.CookingTypeId,
                DishTypeId = model.DishTypeId,
                RecipeTypeId = model.RecipeTypeId,
                Stages = model.Stages?.Select(s => stageMapper.Map(s)).ToList(),
                Ingredients = model.Ingredients?.Select(i => ingredientMapper.Map(i))
            };

            if (model.Thumbnail != null)
            {
                GetThumbnail(recipe, model.Thumbnail);
            }

            return recipe;
        }

        private void GetThumbnail(Recipe recipe, IFormFile file)
        {
            recipe.Thumbnail = fileHandler.GetBytes(file);
            recipe.ThumbnailContentType = fileHandler.GetContentType(file);
        }
    }
}
