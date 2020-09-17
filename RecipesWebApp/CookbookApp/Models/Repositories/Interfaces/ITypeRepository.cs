using System;

namespace KK.Cookbook.Models.Repositories.Interfaces
{
    public interface ITypeRepository
    {
        public void AddNewRecipeType(string name);
        public void AddNewCategoryType(string name);
        public void AddNewDishType(string name);
        public void AddNewIngredientType(string name);

        public void RemoveRecipeType(string name);
        public void RemoveCategoryType(string name);
        public void RemoveDishType(string name);
        public void RemoveIngredientType(string name);
    }
}
