using AutoMapper;
using MediatR;
using ReplacedPartApi.Boundary;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using ReplacedPartApi.Domain;
using ReplacedPartApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReplacedPartApi.Handlers.ReplacedPart
{
    public class GetAllReplacedPartsQueryHandler : IRequestHandler<GetAllReplacedPartRequestModel, List<ReplacedPartResponseModel>>
    {
        private readonly IReplacedPartRepository _repository;
        private readonly IMapper _mapper;

        public GetAllReplacedPartsQueryHandler(IReplacedPartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReplacedPartResponseModel>> Handle(GetAllReplacedPartRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<ReplacedPartDomainModel> replacedParts;
            if (request.RequiredIdType is RequiredIdType.ProductId)
            {
                replacedParts = await _repository.GetAllByProductIdAsync(request.Id).ConfigureAwait(false);
            }
            else
            {
                replacedParts = await _repository.GetAllByRepairIdAsync(request.Id).ConfigureAwait(false);
            }

            return _mapper.Map<List<ReplacedPartResponseModel>>(replacedParts);
        }
    }
}
