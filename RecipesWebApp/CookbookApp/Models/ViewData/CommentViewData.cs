using mekk1t.Tools.Datetime;
using System;

namespace KK.Cookbook.Models.ViewData
{
    public class CommentViewData
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public string WrittenOn { get; set; } = DateTime.UtcNow.ExtractDateTimeAsString();
    }
}