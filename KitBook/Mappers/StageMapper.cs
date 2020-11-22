using System;
using System.IO;
using KitBook.Handlers.Interface;
using KitBook.Mappers.Interfaces;
using KitBook.Models.Database.Entities;
using KitBook.Models.ViewModels;
using KitBook.Models.ViewModels.Stage;
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
                viewModel.ImageBase64 = Convert.ToBase64String(model.Image.Content);
                viewModel.ImageExtension = model.Image.Extension;
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
                GetImage(stage, model.Image);
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
                GetImage(stage, model.Image);
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
                editStage.ExistingImage = new ExistingImageViewModel
                {
                    Base64String = Convert.ToBase64String(model.Image.Content),
                    Extension = model.Image.Extension
                };
            }

            return editStage;
        }

        private void GetImage(Stage stage, IFormFile file)
        {
            stage.Image = new BusinessLogic.Models.Files.File
            {
                Content = fileHandler.GetBytes(file),
                Extension = fileHandler.GetExtension(file)
            };
        }
    }
}
