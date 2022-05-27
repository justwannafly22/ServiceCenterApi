using MediatR;
using System;
using System.Collections.Generic;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class GetAllRepairsRequestModel : IRequest<List<RepairResponseModel>>
    {
        public Guid ClientId { get; set; }
        public Guid MasterId { get; set; }
    }
}
