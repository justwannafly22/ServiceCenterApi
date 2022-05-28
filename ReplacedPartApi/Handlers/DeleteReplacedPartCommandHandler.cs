using AutoMapper;
using Database;
using Database.Domain;
using MediatR;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReplacedPartApi.Handlers.ReplacedPart
{
    public class DeleteReplacedPartCommandHandler : IRequestHandler<DeleteReplacedPartRequestModel>
    {
        private readonly IReplacedPartRepository _repository;
        private readonly IMapper _mapper;

        public DeleteReplacedPartCommandHandler(IReplacedPartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReplacedPartRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var domain = _mapper.Map<ReplacedPartDomainModel>(request);
            await _repository.DeleteAsync(domain).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
