using KK.Cookbook.Models.Database.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.Cookbook.Models.Repositories.Interfaces
{
    public interface IImageRepository
    {
        void AddImageToRecipe(Guid recipeId, Image newImage);
        void ChangeRecipeImage(Guid recipeId, Image editImage);
        void RemoveImageFromRecipe(Guid imageId);
    }
}
