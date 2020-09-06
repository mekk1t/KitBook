using System;
using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.Database.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
    }
}