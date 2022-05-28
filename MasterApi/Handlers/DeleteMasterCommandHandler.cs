using AutoMapper;
using Database;
using Database.Domain;
using MasterApi.Boundary.Master.RequestModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MasterApi.Handlers
{
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteMasterRequestModel>
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public DeleteMasterCommandHandler(IMapper mapper, IMasterRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMasterRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var client = _mapper.Map<MasterDomainModel>(request);
            await _repository.DeleteAsync(client).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
