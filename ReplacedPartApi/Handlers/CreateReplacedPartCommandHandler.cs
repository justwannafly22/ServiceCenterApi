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
    public class CreateReplacedPartCommandHandler : IRequestHandler<CreateReplacedPartRequestModel, ReplacedPartResponseModel>
    {
        private readonly IReplacedPartRepository _repository;
        private readonly IMapper _mapper;

        public CreateReplacedPartCommandHandler(IReplacedPartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReplacedPartResponseModel> Handle(CreateReplacedPartRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _mapper.Map<ReplacedPartDomainModel>(request);

            return _mapper.Map<ReplacedPartResponseModel>(await _repository.CreateAsync(model).ConfigureAwait(false));
        }
    }
}
