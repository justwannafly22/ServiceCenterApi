using AutoMapper;
using Database.Domain;
using ReplacedPartApi.Boundary;
using ReplacedPartApi.Boundary.ReplacedParts;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;

namespace ReplacedPartApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReplacedPartDomainModel, ReplacedPartResponseModel>()
                .ForMember(r => r.TotalPrice,
                    opt => opt.MapFrom(x => x.Count * x.Price));

            CreateMap<CreateReplacedPartRequestModel, ReplacedPartDomainModel>();
            CreateMap<UpdateReplacedPartModel, ReplacedPartDomainModel>();
            CreateMap<GetByIdReplacedPartRequestModel, ReplacedPartDomainModel>();
            CreateMap<GetAllReplacedPartRequestModel, ReplacedPartDomainModel>();
            CreateMap<DeleteReplacedPartRequestModel, ReplacedPartDomainModel>();
        }
    }
}
