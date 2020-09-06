using KK.Cookbook.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.Cookbook.Models.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetRecipeCategories(Guid recipeId);
    }
}
