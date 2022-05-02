using MediatR;
using System.Collections.Generic;

namespace MasterApi.Boundary.Master.RequestModels
{
    public class GetAllMastersRequestModel : IRequest<List<MasterResponseModel>>
    {
    }
}
