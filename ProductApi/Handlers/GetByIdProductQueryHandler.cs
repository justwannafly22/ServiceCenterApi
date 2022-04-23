using AutoMapper;
using Light.GuardClauses;
using MediatR;
using ProductApi.Boundary;
using ProductApi.Boundary.RequestModels;
using ProductApi.Domain;
using ProductApi.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Handlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductRequestModel, ProductResponseModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponseModel> Handle(GetByIdProductRequestModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domain = _mapper.Map<ProductDomainModel>(request);
            var product = await _repository.GetByIdAsync(domain).ConfigureAwait(false);

            return _mapper.Map<ProductResponseModel>(product) ?? null;
        }
    }
}
