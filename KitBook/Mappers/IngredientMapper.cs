using System;
using System.Linq;
using KitBook.Mappers.Interfaces;
using KitBook.Models.Database.Entities;
using KitBook.Models.ViewModels;
using KitBook.Models.ViewModels.Ingredient;

namespace KitBook.Mappers
{
    public class IngredientMapper : IIngredientMapper
    {
        public IngredientViewModel Map(Ingredient model)
        {
            var viewModel = new IngredientViewModel
            {
                Id = model.Id,
                Name = model.Name,
                IsSour = model.IsSour,
                IsSpicy = model.IsSpicy,
                IsSugary = model.IsSugary,
                IngredientType = model.Type?.Name
            };

            if (model.Recipes?.Count > 0)
            {
                viewModel.References = model.Recipes.Select(r => new IngredientRecipeReference
                {
                    RecipeId = r.RecipeId,
                    RecipeTitle = r.Recipe?.Title
                });
            }

            return viewModel;
        }

        public RecipeIngredientViewModel Map(RecipeIngredient model)
        {
            return new RecipeIngredientViewModel
            {
                RecipeId = model.RecipeId,
                IngredientId = model.IngredientId,
                Amount = model.Amount,
                G = model.G,
                Ml = model.Ml,
                IngredientName = model.Ingredient.Name
            };
        }

        public Ingredient Map(EditIngredient model)
        {
            return new Ingredient
            {
                Id = model.Id,
                Name = model.Name,
                IsSour = model.IsSour,
                IsSpicy = model.IsSpicy,
                IsSugary = model.IsSugary,
                IngredientTypeId = model.IngredientTypeId
            };
        }

        public Ingredient Map(NewIngredient model)
        {
            return new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                IsSour = model.IsSour,
                IsSpicy = model.IsSpicy,
                IsSugary = model.IsSugary,
                IngredientTypeId = model.IngredientTypeId
            };
        }

        public RecipeIngredient Map(RecipeIngredientViewModel model)
        {
            return new RecipeIngredient
            {
                RecipeId = model.RecipeId,
                IngredientId = model.IngredientId,
                Amount = model.Amount,
                G = model.G,
                Ml = model.Ml
            };
        }

        public EditIngredient MapToEdit(Ingredient model)
        {
            return new EditIngredient
            {
                Id = model.Id,
                Name = model.Name,
                IsSour = model.IsSour,
                IsSpicy = model.IsSpicy,
                IsSugary = model.IsSugary,
                IngredientTypeId = model.IngredientTypeId
            };
        }
    }
}
