using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Boundary.Client.ResponseModels;
using ClientApi.Factories;
using ClientApi.Repository.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApi.Handlers
{
    public class GetClientByAttendeeIdQueryHandler : IRequestHandler<GetClientByAttendeeIdRequestModel, ClientResponseModel>
    {
        private readonly IClientRepository _repository;
        private readonly IDomainFactory _factory;

        public GetClientByAttendeeIdQueryHandler(IClientRepository repository, IDomainFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ClientResponseModel> Handle(GetClientByAttendeeIdRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _factory.ToDomain(request);
            var client = await _repository.GetByAttendeeIdAsync(model).ConfigureAwait(false);

            return _factory.ToResponseModel(client);
        }
    }
}
