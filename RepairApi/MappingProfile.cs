using AutoMapper;
using Database.Domain;
using RepairApi.Boundary.Repair;
using RepairApi.Boundary.Repair.RequestModels;

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
