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
    public class UpdateRepairCommandHandler : IRequestHandler<UpdateRepairRequestModel, RepairResponseModel>
    {
        private readonly IRepairRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRepairCommandHandler(IRepairRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RepairResponseModel> Handle(UpdateRepairRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _mapper.Map<RepairDomainModel>(request);
            var updatedRepair = await _repository.UpdateAsync(model).ConfigureAwait(false);

            return _mapper.Map<RepairResponseModel>(updatedRepair);
        }
    }
}
