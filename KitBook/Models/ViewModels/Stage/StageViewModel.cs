using System;

namespace KitBook.Models.ViewModels
{
    public class StageViewModel
    {
        public Guid RecipeId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public string ImageExtension{ get; set; }
    }
}