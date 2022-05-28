using AutoMapper;
using Database;
using Database.Domain;
using MediatR;
using ReplacedPartApi.Boundary;
using ReplacedPartApi.Boundary.ReplacedParts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReplacedPartApi.Handlers.ReplacedPart
{
    public class UpdateReplacedPartCommandHandler : IRequestHandler<UpdateReplacedPartModel, ReplacedPartResponseModel>
    {
        private readonly IReplacedPartRepository _repository;
        private readonly IMapper _mapper;

        public UpdateReplacedPartCommandHandler(IReplacedPartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReplacedPartResponseModel> Handle(UpdateReplacedPartModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var domain = _mapper.Map<ReplacedPartDomainModel>(request);
            var updatedReplacedPart = await _repository.UpdateAsync(domain).ConfigureAwait(false);

            return _mapper.Map<ReplacedPartResponseModel>(updatedReplacedPart);
        }
    }
}
