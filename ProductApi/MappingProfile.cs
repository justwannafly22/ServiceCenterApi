using AutoMapper;
using Database.Domain;
using ProductApi.Boundary;
using ProductApi.Boundary.RequestModels;

namespace ProductApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductRequestModel, ProductDomainModel>();
            CreateMap<UpdateProductModel, ProductDomainModel>();
            CreateMap<GetByIdProductRequestModel, ProductDomainModel>();
            CreateMap<DeleteProductRequestModel, ProductDomainModel>();
            CreateMap<ProductDomainModel, ProductResponseModel>();
        }
    }
}
