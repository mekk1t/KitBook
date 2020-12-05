using System;
using BusinessLogic.Models;
using KitBook.Utils;
using KitBook.ViewModels;
using Microsoft.AspNetCore.Http;

namespace KitBook.Mappers
{
    public class StageMapper : IStageMapper
    {
        private readonly IFileHandler<IFormFile> fileHandler;

        public StageMapper(IFileHandler<IFormFile> fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        public StageViewModel Map(Stage model)
        {
            var viewModel = new StageViewModel
            {
                Description = model.Description,
                Index = model.Index,
                RecipeId = model.RecipeId
            };

            if (model.Image != null)
            {
                viewModel.Image = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.Image.Content),
                    Extension = model.Image.Extension
                };
            }
            return viewModel;
        }

        public Stage Map(NewStage model)
        {
            var stage = new Stage
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Index = model.Index,
                RecipeId = model.RecipeId
            };

            if (model.Image != null)
            {
                stage.Image = GetImage(model.Image);
            }

            return stage;
        }

        public Stage Map(EditStage model)
        {
            var stage = new Stage
            {
                Id = model.Id,
                Description = model.Description,
                Index = model.Index,
                RecipeId = model.RecipeId
            };

            if (model.Image != null)
            {
                stage.Image = GetImage(model.Image);
            }
            else if (model.ExistingImage != null)
            {
                stage.Image = new File
                {
                    Content = Convert.FromBase64String(model.ExistingImage.Base64),
                    Extension = model.ExistingImage.Extension
                };
            }

            return stage;
        }

        public EditStage MapToEdit(Stage model)
        {
            var editStage = new EditStage
            {
                Id = model.Id,
                Description = model.Description,
                Index = model.Index,
                RecipeId = model.RecipeId
            };

            if (model.Image != null)
            {
                editStage.ExistingImage = new ImageViewModel
                {
                    Base64 = Convert.ToBase64String(model.Image.Content),
                    Extension = model.Image.Extension
                };
            }

            return editStage;
        }

        private File GetImage(IFormFile file)
        {
            return new File
            {
                Content = fileHandler.GetBytes(file),
                Extension = fileHandler.GetExtension(file)
            };
        }
    }
}
