using AutoMapper;
using Database;
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
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsByClientIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseModel>> Handle(GetProductsByClientIdRequestModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domainProducts = await _repository.GetAllAsync().ConfigureAwait(false);

            return _mapper.Map<List<ProductResponseModel>>(domainProducts);
        }
    }
}
