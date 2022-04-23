using MediatR;
using System.Collections.Generic;

namespace RepairApi.Boundary.Repair.RequestModels
{
    public class GetAllRepairsRequestModel : IRequest<List<RepairResponseModel>>
    {
    }
}
