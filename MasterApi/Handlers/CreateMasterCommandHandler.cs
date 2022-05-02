using AutoMapper;
using MasterApi.Boundary.Master;
using MasterApi.Boundary.Master.RequestModels;
using MasterApi.Domain;
using MasterApi.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MasterApi.Handlers
{
    public class CreateMasterCommandHandler : IRequestHandler<CreateMasterRequestModel, MasterResponseModel>
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public CreateMasterCommandHandler(IMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MasterResponseModel> Handle(CreateMasterRequestModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var domain = _mapper.Map<MasterDomainModel>(request);
            var master = await _repository.CreateAsync(domain).ConfigureAwait(false);

            return _mapper.Map<MasterResponseModel>(master);
        }
    }
}
