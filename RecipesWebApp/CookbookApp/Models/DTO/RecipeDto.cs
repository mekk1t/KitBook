using KK.Cookbook.Models.Database.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.DTO
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(CookingType))]
        public CookingType CookingType { get; set; }
        [EnumDataType(typeof(RecipeType))]
        public RecipeType RecipeType { get; set; }
        [EnumDataType(typeof(DishType))]
        public DishType DishType { get; set; }
        public string SourceURL { get; set; }
    }
}
