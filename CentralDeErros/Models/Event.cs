using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErros.Models
{
    [Table("event")]
    public class Event
    {

        [Column("Id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("level")]
        [StringLength(45)]
        [Required]
        public string Level { get; set; }

        [Column("description")]
        [StringLength(250)]
        [Required]
        public string Description { get; set; }

        [Column("origin")]
        [StringLength(250)]
        [Required]
        public string Origin { get; set; }

        [Column("data")]
        [Required]
        public DateTime Data { get; set; }

        [Column("log")]
        [StringLength(4000)]
        [Required]
        public string Log { get; set; }

        [Column("environment")]
        [StringLength(45)]
        [Required]
        public string Environment { get; set; }

        [Column("archived")]
        [Required]
        public byte Archived { get; set; }

        [Column("logId")]
        [StringLength(45)]
        [Required]
        public string LogId { get; set; }

        [Column("title")]
        [StringLength(45)]
        [Required]
        public string Title { get; set; }

        [Column("collectedBy")]
        [StringLength(45)]
        [Required]
        public string CollectedBy { get; set; }
    }
}
