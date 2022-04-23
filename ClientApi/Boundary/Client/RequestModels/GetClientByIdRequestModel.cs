using ClientApi.Boundary.Client.ResponseModels;
using MediatR;
using System;

namespace ClientApi.Boundary.Client.RequestModels
{
    public class GetClientByIdRequestModel : IRequest<ClientResponseModel>
    {
        public Guid Id { get; set; }
    }
}
