using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReplacedPartApi.Repository.Entities
{
    public class ReplacedPart
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("replaced_part_name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Column("replaced_part_count")]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        [Column("advanced_info")]
        [Required]
        [MaxLength(500)]
        public string AdvancedInfo { get; set; }

        [Column("repair_id")]
        public Guid RepairId { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }
    }
}
