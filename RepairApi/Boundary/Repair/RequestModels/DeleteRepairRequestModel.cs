using MediatR;
using System;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class DeleteRepairRequestModel : IRequest
    {
        //[Required]
        public Guid Id { get; set; }
    }
}
