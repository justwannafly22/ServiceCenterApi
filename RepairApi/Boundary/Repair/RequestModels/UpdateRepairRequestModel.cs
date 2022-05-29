using MediatR;
using System;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class UpdateRepairRequestModel : IRequest<RepairResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public string Status { get; set; }
        public Guid? MasterId { get; set; }
    }
}
