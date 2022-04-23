using AutoMapper;
using MediatR;
using ReplacedPartApi.Boundary;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using ReplacedPartApi.Domain;
using ReplacedPartApi.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReplacedPartApi.Handlers.ReplacedPart
{
    public class GetReplacedPartQueryHandler : IRequestHandler<GetByIdReplacedPartRequestModel, ReplacedPartResponseModel>
    {
        private readonly IReplacedPartRepository _repository;
        private readonly IMapper _mapper;

        public GetReplacedPartQueryHandler(IReplacedPartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReplacedPartResponseModel> Handle(GetByIdReplacedPartRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var domain = _mapper.Map<ReplacedPartDomainModel>(request);

            return _mapper.Map<ReplacedPartResponseModel>(await _repository.GetByIdAsync(domain).ConfigureAwait(false));
        }
    }
}
