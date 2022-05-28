using AutoMapper;
using Database;
using Database.Domain;
using MasterApi.Boundary.Master;
using MasterApi.Boundary.Master.RequestModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MasterApi.Handlers
{
    public class GetMasterByIdQueryHandler : IRequestHandler<GetMasterByIdRequestModel, MasterResponseModel>
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public GetMasterByIdQueryHandler(IMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MasterResponseModel> Handle(GetMasterByIdRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var model = _mapper.Map<MasterDomainModel>(request);
            var master = await _repository.GetByIdAsync(model).ConfigureAwait(false);

            return _mapper.Map<MasterResponseModel>(master);
        }
    }
}
