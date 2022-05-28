using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Repair
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [ForeignKey(nameof(RepairInfo))]
        [Column("repairinfo_id")]
        public Guid RepairInfoId { get; set; }
        public RepairInfo RepairInfo { get; set; }

        [Column("client_id")]
        public Guid ClientId { get; set; }
        
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Column("master_id")]
        public Guid MasterId { get; set; }
    }
}
