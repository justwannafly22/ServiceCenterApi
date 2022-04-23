using MediatR;
using System;

namespace ClientApi.Boundary.Client.RequestModels
{
    public class DeleteClientRequestModel : IRequest
    {
        public Guid Id { get; set; }
    }
}
