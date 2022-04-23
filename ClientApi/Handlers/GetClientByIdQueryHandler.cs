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
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdRequestModel, ClientResponseModel>
    {
        private readonly IClientRepository _repository;
        private readonly IDomainFactory _factory;

        public GetClientByIdQueryHandler(IClientRepository repository, IDomainFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ClientResponseModel> Handle(GetClientByIdRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _factory.ToDomain(request);
            var client = await _repository.GetByIdAsync(model).ConfigureAwait(false);

            return _factory.ToResponseModel(client);
        }
    }
}
