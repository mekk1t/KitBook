﻿using System;
using System.Linq;
using BusinessLogic.Models;
using KitBook.Utils;
using KitBook.ViewModels;
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
                viewModel.Thumbnail = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.Thumbnail.Content),
                    Extension = model.Thumbnail.Extension
                };
            };

            if (model.CookingType?.Icon != null)
            {
                viewModel.CookingTypeIcon = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.CookingType.Icon.Content),
                    Extension = model.CookingType.Icon.Extension
                };
            }
            if (model.RecipeType?.Icon != null)
            {
                viewModel.RecipeTypeIcon = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.RecipeType.Icon.Content),
                    Extension = model.RecipeType.Icon.Extension
                };
            }
            if (model.DishType?.Icon != null)
            {
                viewModel.DishTypeIcon = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.DishType.Icon.Content),
                    Extension = model.DishType.Icon.Extension
                };
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
                Ingredients = model.Ingredients?.Select(i => ingredientMapper.Map(i)).ToList()
            };

            if (model.Thumbnail != null)
            {
                recipe.Thumbnail = GetThumbnail(model.Thumbnail);
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
                Ingredients = model.Ingredients?.Select(i => ingredientMapper.Map(i)).ToList()
            };

            if (model.Thumbnail != null)
            {
                recipe.Thumbnail = GetThumbnail(model.Thumbnail);
            }
            else if (model.ExistingImage != null)
            {
                recipe.Thumbnail = new File
                {
                    Content = Convert.FromBase64String(model.ExistingImage.Base64),
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
                editRecipe.ExistingImage = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.Thumbnail.Content),
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
