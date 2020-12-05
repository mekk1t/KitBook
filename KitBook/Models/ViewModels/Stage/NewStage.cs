using System;
using Microsoft.AspNetCore.Http;

namespace KitBook.ViewModels
{
    public class NewStage
    {
        public Guid RecipeId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
