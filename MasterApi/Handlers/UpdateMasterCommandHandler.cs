using AutoMapper;
using Database;
using Database.Domain;
using MasterApi.Boundary.Master;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MasterApi.Handlers
{
    public class UpdateMasterCommandHandler : IRequestHandler<UpdateMasterModel, MasterResponseModel>
    {
        private readonly IMasterRepository _repository;
        private readonly IMapper _mapper;

        public UpdateMasterCommandHandler(IMapper mapper, IMasterRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MasterResponseModel> Handle(UpdateMasterModel request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var client = _mapper.Map<MasterDomainModel>(request);
            var updatedMaster = await _repository.UpdateAsync(client).ConfigureAwait(false);

            return _mapper.Map<MasterResponseModel>(updatedMaster);
        }
    }
}
