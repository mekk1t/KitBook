using System;
using BusinessLogic.Models.Types.Interface;
using KitBook.Handlers.Interface;
using KitBook.Mappers.Interfaces;
using KitBook.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace KitBook.Mappers
{
    public class TypeMapper : ITypeMapper
    {
        private readonly IFileHandler<IFormFile> fileHandler;

        public TypeMapper(IFileHandler<IFormFile> fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        public T Map<T>(TypeViewModel viewModel)
            where T:IType, new()
        {
            return new T
            {
                Id = viewModel.Id == Guid.Empty
                ? Guid.NewGuid()
                : viewModel.Id,
                Name = viewModel.Name,
                Icon = new BusinessLogic.Models.Files.File
                {
                    Extension = fileHandler.GetExtension(viewModel.Icon),
                    Content = fileHandler.GetBytes(viewModel.Icon)
                }
            };
        }

        public TypeViewModel Map<T>(T typeModel) where T : IType, new()
        {
            var viewModel = new TypeViewModel
            {
                Id = typeModel.Id,
                Name = typeModel.Name
            };

            if (typeModel.Icon != null)
            {
                viewModel.ExistingIcon = new ExistingImageViewModel
                {
                    Base64String = Convert.ToBase64String(typeModel.Icon.Content),
                    Extension = typeModel.Icon.Extension
                };
            }

            return viewModel;
        }
    }
}
