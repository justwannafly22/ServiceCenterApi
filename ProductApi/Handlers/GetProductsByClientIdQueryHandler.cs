using AutoMapper;
using Database;
using Database.Domain;
using Light.GuardClauses;
using MediatR;
using ProductApi.Boundary;
using ProductApi.Boundary.RequestModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Handlers
{
    public class GetProductsByClientIdQueryHandler : IRequestHandler<GetProductsByClientIdRequestModel, List<ProductResponseModel>>
    {
        private readonly IRepairRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsByClientIdQueryHandler(IRepairRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseModel>> Handle(GetProductsByClientIdRequestModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domainProducts = await _repository.GetProductsByClientIdAsync(new RepairDomainModel() { ClientId = request.ClientId }).ConfigureAwait(false);

            return _mapper.Map<List<ProductResponseModel>>(domainProducts);
        }
    }
}
