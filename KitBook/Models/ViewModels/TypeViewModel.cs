using System;
using Microsoft.AspNetCore.Http;

namespace KitBook.Models.ViewModels
{
    public class TypeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }
}
