using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDetailsDto>();

        CreateMap<Product, ListProductDto>();

        
    }

}
