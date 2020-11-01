using System.Collections.Generic;
using System.Linq;
using KitBook.Models.Database.Entities;
using KitBook.Models.DTO;

namespace KitBook.Helpers.Extensions
{
    public static class MappingExtensions
    {
        public static Recipe AsEntity(this RecipeDto dto)
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
                    Id = s.Id,
                    Index = s.Index,
                    RecipeId = s.RecipeId
                }).ToList()
            };
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
                    RecipeId = s.RecipeId
                }).ToList()
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
                IngredientTypeId = entity.IngredientTypeId
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
