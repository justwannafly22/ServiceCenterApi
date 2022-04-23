using ClientApi.Boundary.Client.ResponseModels;
using MediatR;
using System.Collections.Generic;

namespace ClientApi.Boundary.Client.RequestModels
{
    public class GetAllClientsRequestModel : IRequest<List<ClientResponseModel>>
    {
    }
}
