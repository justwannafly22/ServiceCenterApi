using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Product
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("product_name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Column("product_description")]
        [Required]
        public string Description { get; set; }
    }
}
