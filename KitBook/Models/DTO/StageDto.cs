using System;
using Microsoft.AspNetCore.Http;

namespace KitBook.Models.DTO
{
    public class StageDto
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }

        public int Index { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string ImageBase64 { get; set; }
    }
}