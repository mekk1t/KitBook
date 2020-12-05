using System;
using Microsoft.AspNetCore.Http;

namespace KitBook.ViewModels
{
    public class TypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile Icon { get; set; }

        public ImageViewModel ExistingIcon { get; set; }
        public string KindOfType { get; set; }
        public string KindOfTypeTranslated { get; set; }
    }
}
