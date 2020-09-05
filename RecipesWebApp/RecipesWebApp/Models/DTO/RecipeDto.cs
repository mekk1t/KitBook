using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWebApp.Models.DTO
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public List<string> Ingredients { get; set; }
        public string CookingType { get; set; }
        public string Description { get; set; }
        public DateTime CookingTime { get; set; }
        public string DishType { get; set; }
    }
}
