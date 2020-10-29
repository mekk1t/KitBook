using KitBook.Models.Database.Entities.Types;

namespace KitBook.Models.Repositories.Interfaces
{
    public interface ITypeRepository :
        IRepository<RecipeType>,
        IRepository<CookingType>,
        IRepository<IngredientType>,
        IRepository<DishType>
    {
    }
}
