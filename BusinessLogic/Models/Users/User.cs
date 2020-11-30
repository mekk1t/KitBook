using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Models.Files;
using BusinessLogic.Models.Users;

namespace KitBook.Models.Database.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }

        public Guid? AvatarId { get; set; }
        public File Avatar { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}