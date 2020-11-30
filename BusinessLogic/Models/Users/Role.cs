using System;
using System.Collections.Generic;
using KitBook.Models.Database.Entities;

namespace BusinessLogic.Models.Users
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
