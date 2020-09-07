using KK.Cookbook.Models.DTO;
using KK.Cookbook.Models.Mappers.Interfaces;
using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KK.Cookbook.Models.Mappers
{
    public class RecipeMapper : IMapper<RecipeDto, Recipe>, IMapper<IEnumerable<Recipe>, IEnumerable<RecipeDto>>
    {
        public Recipe Map(RecipeDto value)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Title = value.Title,
                Description = value.Description,
                CookingTimeMinutes = value.Hours * 60 + value.Minutes,
                SourceURL = value.SourceURL
            };
            return recipe;
        }

        public IEnumerable<RecipeDto> Map(IEnumerable<Recipe> recipes)
        {
            List<RecipeDto> recipeDtos = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                recipeDtos.Add(new RecipeDto
                {
                    Title = recipe.Title,
                    Description = recipe.Description,
                    Hours = recipe.CookingTimeMinutes / 60,
                    Minutes = recipe.CookingTimeMinutes % 60,
                    SourceURL = recipe.SourceURL
                });
            }
            return recipeDtos.AsEnumerable();
        }
    }
}
