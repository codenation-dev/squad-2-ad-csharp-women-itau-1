using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.DTO
{
    public class EventDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Log { get; set; }

        [Required]
        public string Environment { get; set; }

        [Required]
        public bool Archived { get; set; }

        [Required]
        public string LogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CollectedBy { get; set; }
    }
}
