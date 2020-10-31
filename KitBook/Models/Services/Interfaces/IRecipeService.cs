using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitBook.Models.DTO;

namespace KitBook.Models.Services.Interfaces
{
    public interface IRecipeService
    {
        void CreateNewRecipe(RecipeDto dto);
        void UpdateRecipe(RecipeDto dto);
        void DeleteRecipeById(Guid id);
        RecipeDto GetRecipeById(Guid id);
        IEnumerable<RecipeDto> GetRecipes();
    }
}
