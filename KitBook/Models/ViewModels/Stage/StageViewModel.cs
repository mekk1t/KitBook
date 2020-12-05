using System;

namespace KitBook.ViewModels
{
    public class StageViewModel
    {
        public Guid RecipeId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public ImageViewModel Image { get; set; }
    }
}