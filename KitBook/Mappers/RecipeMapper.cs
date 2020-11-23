using System;
using IO = System.IO;
using System.Linq;
using BusinessLogic.Models.Files;
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
                Id = model.Id,
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
                viewModel.ThumbnailBase64 = Convert.ToBase64String(model.Thumbnail.Content);
                viewModel.ThumbnailExtension = model.Thumbnail.Extension;
            };

            if (model.CookingType?.Icon != null)
            {
                viewModel.CookingTypeIconBase64 = Convert.ToBase64String(model.CookingType.Icon.Content);
                viewModel.CookingTypeIconExtension = model.CookingType.Icon.Extension;
            }

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
                GetThumbnail(model.Thumbnail);
            }
            return recipe;
        }

        public Recipe Map(EditRecipe model)
        {
            var recipe = new Recipe
            {
                Id = model.Id,
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
                recipe.Thumbnail = GetThumbnail(model.Thumbnail);
            }
            else if (model.ExistingImage != null)
            {
                recipe.Thumbnail = new File
                {
                    Content = Convert.FromBase64String(model.ExistingImage.Base64String),
                    Extension = model.ExistingImage.Extension
                };
            }

            return recipe;
        }

        public EditRecipe MapToEdit(Recipe model)
        {
            var editRecipe = new EditRecipe
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                SourceURL = model.SourceURL,
                CookingTimeMinutes = model.CookingTimeMinutes,
                CookingTypeId = model.CookingTypeId,
                DishTypeId = model.DishTypeId,
                RecipeTypeId = model.RecipeTypeId,
                Stages = model.Stages?.Select(s => stageMapper.MapToEdit(s)).ToList(),
                Ingredients = model.Ingredients?.Select(i => ingredientMapper.Map(i)).ToList()
            };

            if (model.Thumbnail != null)
            {
                editRecipe.ExistingImage = new ExistingImageViewModel
                {
                    Base64String = Convert.ToBase64String(model.Thumbnail.Content),
                    Extension = model.Thumbnail.Extension
                };
            }

            return editRecipe;
        }

        private File GetThumbnail(IFormFile file)
        {
            return new File
            {
                Content = fileHandler.GetBytes(file),
                Extension = fileHandler.GetExtension(file)
            };
        }
    }
}
