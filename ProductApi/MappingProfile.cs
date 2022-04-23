using AutoMapper;
using ProductApi.Boundary;
using ProductApi.Boundary.RequestModels;
using ProductApi.Domain;

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
