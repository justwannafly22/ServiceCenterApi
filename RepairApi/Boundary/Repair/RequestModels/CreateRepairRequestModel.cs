using MediatR;
using System;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class CreateRepairRequestModel : IRequest<RepairResponseModel>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        public string Status { get; set; }
        public Guid? MasterId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
    }
}
