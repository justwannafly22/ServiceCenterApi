using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApi.Repository
{
    public class Master
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("master_name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Column("master_surname")]
        [Required]
        [MaxLength(60)]
        public string Surname { get; set; }

        [Column("age")]
        [Range(0, 150)]
        [Required]
        public int Age { get; set; }

        [Column("contact_number")]
        [Required]
        public string ContactNumber { get; set; }
    }
}
