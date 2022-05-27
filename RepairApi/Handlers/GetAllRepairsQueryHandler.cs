using AutoMapper;
using MediatR;
using RepairApi.Boundary.Repair;
using RepairApi.Boundary.Repair.RequestModels;
using RepairApi.Domain;
using RepairApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RepairApi.Handlers
{
    public class GetAllRepairsQueryHandler : IRequestHandler<GetAllRepairsRequestModel, List<RepairResponseModel>>
    {
        private readonly IRepairRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRepairsQueryHandler(IRepairRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RepairResponseModel>> Handle(GetAllRepairsRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            List<RepairDomainModel> repairs;
            if (request.MasterId != Guid.Empty)
            {
                repairs = await _repository.GetAllByMasterIdAsync(new RepairDomainModel() { MasterId = request.MasterId }).ConfigureAwait(false);
            }
            else if (request.ClientId != Guid.Empty)
            {
                repairs = await _repository.GetAllByClientIdAsync(new RepairDomainModel() { ClientId = request.ClientId }).ConfigureAwait(false);
            }
            else
            {
                repairs = await _repository.GetAllAsync().ConfigureAwait(false);
            }

            return _mapper.Map<List<RepairResponseModel>>(repairs);
        }
    }
}
