using AutoMapper;
using MediatR;
using RepairApi.Boundary.Repair;
using RepairApi.Boundary.Repair.RequestModels;
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

            var repairs = await _repository.GetAllAsync().ConfigureAwait(false);

            return _mapper.Map<List<RepairResponseModel>>(repairs);
        }
    }
}
