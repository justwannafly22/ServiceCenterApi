using AutoMapper;
using RepairApi.Boundary.Repair;
using RepairApi.Boundary.Repair.RequestModels;
using RepairApi.Domain;

namespace RepairApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RepairDomainModel, RepairResponseModel>();
            CreateMap<CreateRepairRequestModel, RepairDomainModel>();
            CreateMap<UpdateRepairRequestModel, RepairDomainModel>();
            CreateMap<GetByIdRepairRequestModel, RepairDomainModel>();
            CreateMap<GetAllRepairsRequestModel, RepairDomainModel>();
            CreateMap<DeleteRepairRequestModel, RepairDomainModel>();
        }
    }
}
