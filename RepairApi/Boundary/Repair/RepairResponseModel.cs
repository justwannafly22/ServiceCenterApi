using System;

namespace RepairApi.Boundary.Repair
{
    public class RepairResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string AdvancedInfo { get; set; }

        public string StatusInfo { get; set; }
    }
}
