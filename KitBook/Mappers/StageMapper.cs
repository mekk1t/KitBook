using System;
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
            return new StageViewModel
            {
                Description = model.Description,
                Index = model.Index,
                RecipeId = model.RecipeId,
                ImageBase64 = Convert.ToBase64String(model.Image),
                ImageContentType = model.ImageContentType
            };
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

        private void GetImage(Stage stage, IFormFile file)
        {
            stage.Image = fileHandler.GetBytes(file);
            stage.ImageContentType = fileHandler.GetContentType(file);
        }
    }
}
