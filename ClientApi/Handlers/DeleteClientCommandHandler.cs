using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Factories;
using Database;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApi.Handlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientRequestModel>
    {
        private readonly IClientRepository _repository;
        private readonly IDomainFactory _factory;

        public DeleteClientCommandHandler(IDomainFactory factory, IClientRepository repository)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<Unit> Handle(DeleteClientRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var client = _factory.ToDomain(request);
            await _repository.DeleteAsync(client).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
