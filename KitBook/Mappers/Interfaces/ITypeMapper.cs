using BusinessLogic.Abstractions;
using KitBook.ViewModels;

namespace KitBook.Mappers
{
    public interface ITypeMapper
    {
        T Map<T>(TypeViewModel viewModel)
            where T : IType, new();
        TypeViewModel Map<T>(T typeModel)
            where T : IType, new();
    }
}
