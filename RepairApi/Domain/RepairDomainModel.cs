using System;

namespace RepairApi.Domain
{
    public class RepairDomainModel
    {
        /// <summary>
        /// Repair Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Repair Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// RepairInfo Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// RepairInfo AdvancedInfo
        /// </summary>
        public string AdvancedInfo { get; set; }

        /// <summary>
        /// RepairInfo Status
        /// </summary>
        public string Status { get; set; }
    }
}
