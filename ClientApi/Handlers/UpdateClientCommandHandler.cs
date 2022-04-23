using ClientApi.Boundary.Client;
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
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientModel, ClientResponseModel>
    {
        private readonly IClientRepository _repository;
        private readonly IDomainFactory _factory;

        public UpdateClientCommandHandler(IDomainFactory factory, IClientRepository repository)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ClientResponseModel> Handle(UpdateClientModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var client = _factory.ToDomain(request);
            var updatedEntity = await _repository.UpdateAsync(client).ConfigureAwait(false);

            return _factory.ToResponseModel(updatedEntity);
        }
    }
}
