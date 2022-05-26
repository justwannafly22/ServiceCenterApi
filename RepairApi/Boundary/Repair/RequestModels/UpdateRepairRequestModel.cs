using MediatR;
using System;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class UpdateRepairRequestModel : IRequest<RepairResponseModel>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public Guid StatusId { get; set; }
    }
}
