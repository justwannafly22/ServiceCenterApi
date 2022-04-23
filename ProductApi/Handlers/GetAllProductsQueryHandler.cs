using AutoMapper;
using Light.GuardClauses;
using MediatR;
using ProductApi.Boundary;
using ProductApi.Boundary.RequestModels;
using ProductApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsRequestModel, List<ProductResponseModel>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseModel>> Handle(GetAllProductsRequestModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domainProducts = await _repository.GetAllAsync().ConfigureAwait(false);

            return _mapper.Map<List<ProductResponseModel>>(domainProducts);
        }
    }
}
