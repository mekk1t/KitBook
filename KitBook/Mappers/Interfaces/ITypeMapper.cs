using BusinessLogic.Models.Types.Interface;
using KitBook.Models.ViewModels;

namespace KitBook.Mappers.Interfaces
{
    public interface ITypeMapper
    {
        T Map<T>(TypeViewModel viewModel)
            where T : IType, new();
    }
}
