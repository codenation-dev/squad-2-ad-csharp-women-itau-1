using System;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.DTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
