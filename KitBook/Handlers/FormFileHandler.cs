using System.IO;
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

        public string GetContentType(IFormFile file)
        {
            return file.ContentType;
        }
    }
}
