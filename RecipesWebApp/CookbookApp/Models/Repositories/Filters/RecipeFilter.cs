using KK.Cookbook.Models.Database.Enums;
using System;
using System.Collections.Generic;

namespace KK.Cookbook.Models.Repositories.Filters
{
    // Должен быть выбор у пользователя с возможностью ручного ввода
    public class RecipeFilter
    {
        public TimeSpan CookingTime { get; set; }
        public CookingType CookingType { get; set; }
        public RecipeType RecipeType { get; set; }
        public DishType DishType { get; set; }
        public List<Guid> IngredientIds { get; set; }
        public List<Guid> CategoryIds { get; set; }
        public int StagesCount { get; set; }
    }
}