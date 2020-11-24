using System;
using Microsoft.AspNetCore.Http;

namespace KitBook.Models.ViewModels.Stage
{
    public class EditStage
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }

        public ImageViewModel ExistingImage { get; set; }
    }
}
