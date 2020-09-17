using KK.Cookbook.Models.Database;
using KK.Cookbook.Models.Database.Entities.Types;
using KK.Cookbook.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.Cookbook.Models.Repositories
{
    public class TypesRepository : ITypeRepository
    {
        private readonly CookbookDbContext dbContext;

        public TypesRepository(CookbookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddNewCookingType(string name)
        {
            dbContext.CookingTypes.Add(new CookingType
            {
                Id = Guid.NewGuid(),
                Name = name
            });

            dbContext.SaveChanges();
        }

        public void AddNewDishType(string name)
        {
            dbContext.DishTypes.Add(new DishType
            {
                Id = Guid.NewGuid(),
                Name = name
            });

            dbContext.SaveChanges();
        }

        public void AddNewIngredientType(string name)
        {
            dbContext.IngredientTypes.Add(new IngredientType
            {
                Id = Guid.NewGuid(),
                Name = name
            });

            dbContext.SaveChanges();
        }

        public void AddNewRecipeType(string name)
        {
            dbContext.RecipeTypes.Add(new RecipeType
            {
                Id = Guid.NewGuid(),
                Name = name
            });

            dbContext.SaveChanges();
        }

        public void RemoveCookingType(string name)
        {
            var cookingType = dbContext.CookingTypes.FirstOrDefault(ct => ct.Name == name);
            dbContext.CookingTypes.Remove(cookingType);
            dbContext.SaveChanges();
        }

        public void RemoveDishType(string name)
        {
            var dishType = dbContext.DishTypes.FirstOrDefault(dt => dt.Name == name);
            dbContext.DishTypes.Remove(dishType);
            dbContext.SaveChanges();
        }

        public void RemoveIngredientType(string name)
        {
            var ingredientType = dbContext.IngredientTypes.FirstOrDefault(it => it.Name == name);
            dbContext.IngredientTypes.Remove(ingredientType);
            dbContext.SaveChanges();
        }

        public void RemoveRecipeType(string name)
        {
            var recipeType = dbContext.RecipeTypes.FirstOrDefault(rt => rt.Name == name);
            dbContext.RecipeTypes.Remove(recipeType);
            dbContext.SaveChanges();
        }
    }
}
