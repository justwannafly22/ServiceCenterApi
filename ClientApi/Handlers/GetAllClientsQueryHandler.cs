using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Boundary.Client.ResponseModels;
using ClientApi.Factories;
using ClientApi.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApi.Handlers
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsRequestModel, List<ClientResponseModel>>
    {
        private readonly IClientRepository _repository;
        private readonly IDomainFactory _factory;

        public GetAllClientsQueryHandler(IClientRepository repository, IDomainFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<List<ClientResponseModel>> Handle(GetAllClientsRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var clients = await _repository.GetAllAsync().ConfigureAwait(false);

            return clients.Select(c => _factory.ToResponseModel(c)).ToList();
        }
    }
}
