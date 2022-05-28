using AutoMapper;
using Database;
using Database.Domain;
using MediatR;
using RepairApi.Boundary.Repair;
using RepairApi.Boundary.Repair.RequestModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RepairApi.Handlers
{
    public class GetRepairByIdQueryHandler : IRequestHandler<GetByIdRepairRequestModel, RepairResponseModel>
    {
        private readonly IRepairRepository _repository;
        private readonly IMapper _mapper;

        public GetRepairByIdQueryHandler(IRepairRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RepairResponseModel> Handle(GetByIdRepairRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _mapper.Map<RepairDomainModel>(request);
            var repair = await _repository.GetByIdAsync(model).ConfigureAwait(false);

            return _mapper.Map<RepairResponseModel>(repair);
        }
    }
}
