using System;

namespace mekk1t.Cookbook.Models.Database.Entities.Custom
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public Guid? StageId { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}