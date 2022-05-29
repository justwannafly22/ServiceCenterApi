using System;

namespace Database.Domain
{
    public class ReplacedPartDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string AdvancedInfo { get; set; }
        public Guid RepairId { get; set; }
        public Guid ProductId { get; set; }
    }
}
