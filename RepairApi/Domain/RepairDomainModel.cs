using System;

namespace RepairApi.Domain
{
    public class RepairDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public string Status { get; set; }
        public Guid? MasterId { get; set; }
        public Guid? ClientId { get; set; }
    }
}
