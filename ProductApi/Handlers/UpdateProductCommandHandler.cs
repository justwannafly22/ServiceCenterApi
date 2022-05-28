using AutoMapper;
using Database;
using Database.Domain;
using Light.GuardClauses;
using MediatR;
using ProductApi.Boundary;
using ProductApi.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductModel, ProductResponseModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponseModel> Handle(UpdateProductModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domain = _mapper.Map<ProductDomainModel>(request);

            if (await _repository.GetByIdAsync(domain) is null)
            {
                throw new EntityNotFoundException($"The product with id: {domain.Id} doesn`t exist in the database.");
            }

            return _mapper.Map<ProductResponseModel>(await _repository.UpdateAsync(domain).ConfigureAwait(false));
        }
    }
}
