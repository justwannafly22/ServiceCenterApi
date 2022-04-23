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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductRequestModel, ProductResponseModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponseModel> Handle(CreateProductRequestModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domain = _mapper.Map<ProductDomainModel>(request);

            return _mapper.Map<ProductResponseModel>(await _repository.CreateAsync(domain).ConfigureAwait(false));
        }
    }
}
