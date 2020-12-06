using System;
using BusinessLogic.Abstractions;
using BusinessLogic.Attributes;
using KitBook.Utils;
using KitBook.ViewModels;
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
                Icon = new BusinessLogic.Models.File
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
                Name = typeModel.Name,
                KindOfType = typeof(T).Name,
                KindOfTypeTranslated = (Attribute.GetCustomAttribute(typeof(T), typeof(TranslationAttribute)) as TranslationAttribute).Translation
            };

            if (typeModel.Icon != null)
            {
                viewModel.ExistingIcon = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(typeModel.Icon.Content),
                    Extension = typeModel.Icon.Extension
                };
            }

            return viewModel;
        }
    }
}
