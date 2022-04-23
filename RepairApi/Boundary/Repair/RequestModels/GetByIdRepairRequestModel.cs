using MediatR;
using System;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class GetByIdRepairRequestModel : IRequest<RepairResponseModel>
    {
        //[Required]
        public Guid Id { get; set; }
    }
}
