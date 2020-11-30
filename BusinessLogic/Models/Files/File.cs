using System;

namespace BusinessLogic.Models.Files
{
    public class File
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public string Extension { get; set; }
    }
}
