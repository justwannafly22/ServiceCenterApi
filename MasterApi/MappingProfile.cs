using AutoMapper;
using Database.Domain;
using MasterApi.Boundary.Master;
using MasterApi.Boundary.Master.RequestModels;

namespace MasterApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MasterDomainModel, MasterResponseModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => $"{x.Name} {x.Surname}"));

            CreateMap<CreateMasterRequestModel, MasterDomainModel>();
            CreateMap<UpdateMasterModel, MasterDomainModel>();
            CreateMap<GetMasterByIdRequestModel, MasterDomainModel>();
            CreateMap<GetMasterByAttendeeIdRequestModel, MasterDomainModel>();
            CreateMap<GetAllMastersRequestModel, MasterDomainModel>();
            CreateMap<DeleteMasterRequestModel, MasterDomainModel>();
        }
    }
}
