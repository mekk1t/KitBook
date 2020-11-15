using System;
using System.Collections.Generic;
using System.Linq;
using KitBook.Models.Database.Entities;
using KitBook.Models;
using KitBook.Models.DTO;
using System.IO;
using System.Text;

namespace KitBook.Helpers.Extensions
{
    public static class MappingExtensions
    {
        public static Recipe AsEditEntity(this RecipeDto dto)
        {
            return new Recipe
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title,
                SourceURL = dto.SourceURL,
                CookingTimeMinutes = dto.CookingTimeMinutes,
                CookingTypeId = dto.CookingTypeId,
                DishTypeId = dto.DishTypeId,
                RecipeTypeId = dto.RecipeTypeId,
                Stages = dto.Stages?.Select(s => new Stage
                {
                    Description = s.Description,
                    Id = s.Id == Guid.Empty
                    ? Guid.NewGuid()
                    : s.Id,
                    Index = s.Index,
                    RecipeId = s.RecipeId
                }).ToList(),
                Ingredients = dto.Ingredients?.Select(i => new RecipeIngredient
                {
                    IngredientId = i.IngredientId,
                    RecipeId = i.RecipeId,
                    Amount = i.Amount,
                    G = i.G,
                    Ml = i.Ml
                }).ToList()
            };
        }

        public static Recipe AsNewEntity(this RecipeDto dto)
        {
            var recipe = new Recipe
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title,
                SourceURL = dto.SourceURL,
                CookingTimeMinutes = dto.CookingTimeMinutes,
                CookingTypeId = dto.CookingTypeId,
                DishTypeId = dto.DishTypeId,
                RecipeTypeId = dto.RecipeTypeId,
                Stages = dto.Stages?.Select(s => new Stage
                {
                    Description = s.Description,
                    Id = Guid.NewGuid(),
                    Index = s.Index,
                    RecipeId = s.RecipeId
                }).ToList(),
                Ingredients = dto.Ingredients?.Select(i => new RecipeIngredient
                {
                    IngredientId = i.IngredientId,
                    RecipeId = i.RecipeId,
                    Amount = i.Amount,
                    G = i.G,
                    Ml = i.Ml
                }).ToList()
            };

            if (dto.Thumbnail != null)
            {
                var temp = dto.Thumbnail;
                using var ms = new MemoryStream();
                dto.Thumbnail.CopyTo(ms);
                recipe.Thumbnail = ms.ToArray();
            }

            if (dto.Stages?.Count > 0)
            {
                for (int i = 0; i < dto.Stages.Count; i++)
                {
                    using var ms = new MemoryStream();
                    dto.Stages[i].Image.CopyTo(ms);
                    recipe.Stages[i].Image = ms.ToArray();
                }
            }

            return recipe;
        }

        public static Recipe AsEntity(this RecipeDto dto)
        {
            var entity = new Recipe
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title,
                SourceURL = dto.SourceURL,
                CookingTimeMinutes = dto.CookingTimeMinutes,
                CookingTypeId = dto.CookingTypeId,
                DishTypeId = dto.DishTypeId,
                RecipeTypeId = dto.RecipeTypeId,
                Stages = dto.Stages?.Select(s => new Stage
                {
                    Description = s.Description,
                    Id = s.Id,
                    Index = s.Index,
                    RecipeId = s.RecipeId,
                }).ToList(),
                Ingredients = dto.Ingredients?.Select(i => new RecipeIngredient
                {
                    IngredientId = i.IngredientId,
                    RecipeId = i.RecipeId,
                    Amount = i.Amount,
                    G = i.G,
                    Ml = i.Ml
                }).ToList()
            };

            if (entity.Ingredients?.Count() > 0)
            {
                foreach(var ingredient in entity.Ingredients)
                {
                    ingredient.RecipeId = entity.Id;
                }
            }
            return entity;
        }

        public static RecipeDto AsDto(this Recipe entity)
        {
            return new RecipeDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                SourceURL = entity.SourceURL,
                CookingTimeMinutes = entity.CookingTimeMinutes,
                CookingType = entity.CookingType.Name,
                DishType = entity.DishType.Name,
                RecipeType = entity.RecipeType.Name,
                CookingTypeId = entity.CookingTypeId,
                RecipeTypeId = entity.RecipeTypeId,
                DishTypeId = entity.DishTypeId,
                Stages = entity.Stages?.Select(s => new StageDto
                {
                    Description = s.Description,
                    Id = s.Id,
                    Index = s.Index,
                    RecipeId = s.RecipeId,
                    ImageBase64 = Convert.ToBase64String(s.Image)
                }).ToList(),
                Ingredients = entity.Ingredients?.Select(i => new RecipeIngredientDto
                {
                    IngredientId = i.IngredientId,
                    RecipeId = i.RecipeId,
                    Name = i.Ingredient.Name,
                    G = i.G,
                    Ml = i.Ml,
                    Amount = i.Amount
                }).ToList(),
                ThumbnailBase64 = Convert.ToBase64String(entity.Thumbnail)
            };
        }

        public static IngredientDto AsDto(this Ingredient entity)
        {
            return new IngredientDto
            {
                Id = entity.Id,
                IngredientType = entity.Type.Name,
                IsSour = entity.IsSour,
                IsSpicy = entity.IsSpicy,
                IsSugary = entity.IsSugary,
                Name = entity.Name,
                IngredientTypeId = entity.IngredientTypeId,
                Mentions = entity.Recipes?.Select(m => new IngredientMention
                {
                    RecipeName = m.Recipe.Title,
                    RecipeId = m.RecipeId
                })
            };
        }

        public static Ingredient AsEntity(this IngredientDto dto)
        {
            return new Ingredient
            {
                Id = dto.Id,
                IsSour = dto.IsSour,
                IsSugary = dto.IsSugary,
                IsSpicy = dto.IsSpicy,
                Name = dto.Name,
                IngredientTypeId = dto.IngredientTypeId
            };
        }

        public static IEnumerable<IngredientDto> AsDtoEnumerable(this IEnumerable<Ingredient> ingredients)
        {
            return ingredients.Select(entity => new IngredientDto
            {
                Id = entity.Id,
                IngredientType = entity.Type.Name,
                IsSour = entity.IsSour,
                IsSpicy = entity.IsSpicy,
                IsSugary = entity.IsSugary,
                Name = entity.Name
            });
        }

        public static IEnumerable<RecipeDto> AsDtoEnumerable(this IEnumerable<Recipe> recipes)
        {
            return recipes.Select(entity => new RecipeDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                SourceURL = entity.SourceURL,
                CookingTimeMinutes = entity.CookingTimeMinutes,
                CookingType = entity.CookingType.Name,
                DishType = entity.DishType.Name,
                RecipeType = entity.RecipeType.Name,
                Stages = entity.Stages?.Select(s => new StageDto
                {
                    Description = s.Description,
                    Id = s.Id,
                    Index = s.Index,
                    RecipeId = s.RecipeId
                }).ToList()
            });
        }
    }
}
