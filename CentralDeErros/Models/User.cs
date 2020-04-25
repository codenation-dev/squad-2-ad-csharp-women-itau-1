using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CentralDeErros.Models
{
    [Table("user")]
    public class User
    {
        [Column("Id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("Login")]
        [StringLength(45)]
        [Required]
        public string Login { get; set; }

        [Column("Password")]
        [StringLength(45)]
        [Required]
        public string Password { get; set; }

        [Column("Created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

    }
}
