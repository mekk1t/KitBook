using System.IO;
using System.Linq;
using KitBook.Handlers.Interface;
using Microsoft.AspNetCore.Http;

namespace KitBook.Handlers
{
    public class FormFileHandler : IFileHandler<IFormFile>
    {
        public byte[] GetBytes(IFormFile file)
        {
            using var ms = new MemoryStream();
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public string GetExtension(IFormFile file)
        {
            return file.FileName.Split('.').Last();
        }
    }
}
