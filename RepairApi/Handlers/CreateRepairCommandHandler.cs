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
    public class CreateRepairCommandHandler : IRequestHandler<CreateRepairRequestModel, RepairResponseModel>
    {
        private readonly IRepairRepository _repository;
        private readonly IMapper _mapper;

        public CreateRepairCommandHandler(IRepairRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RepairResponseModel> Handle(CreateRepairRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _mapper.Map<RepairDomainModel>(request);
            var addedRepair = await _repository.CreateAsync(model).ConfigureAwait(false);

            return _mapper.Map<RepairResponseModel>(addedRepair);
        }
    }
}
