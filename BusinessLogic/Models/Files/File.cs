using System;

namespace BusinessLogic.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public string Extension { get; set; }
    }
}
