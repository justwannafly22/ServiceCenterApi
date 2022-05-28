using AutoMapper;
using Database;
using Database.Domain;
using Light.GuardClauses;
using MediatR;
using ProductApi.Boundary.RequestModels;
using ProductApi.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductRequestModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductRequestModel request, CancellationToken cancellationToken)
        {
            request.MustNotBeNull(nameof(request));

            var domain = _mapper.Map<ProductDomainModel>(request);

            if (await _repository.GetByIdAsync(domain) is null)
            {
                throw new EntityNotFoundException($"The product with id: {domain.Id} doesn`t exist in the database.");
            }

            await _repository.DeleteAsync(domain);

            return Unit.Value;
        }
    }
}
