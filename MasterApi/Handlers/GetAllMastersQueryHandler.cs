using AutoMapper;
using Database;
using MasterApi.Boundary.Master;
using MasterApi.Boundary.Master.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MasterApi.Handlers
{
    public class GetAllMastersQueryHandler : IRequestHandler<GetAllMastersRequestModel, List<MasterResponseModel>>
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMastersQueryHandler(IMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MasterResponseModel>> Handle(GetAllMastersRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var masters = await _repository.GetAllAsync().ConfigureAwait(false);

            return _mapper.Map<List<MasterResponseModel>>(masters);
        }
    }
}
