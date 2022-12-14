using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductResponseDto>()
            .ForMember(
                    d => d.ProductBrand,
                    o => o.MapFrom(
                            s => s.ProductBrand.Name
                        )
                )
            .ForMember(
                d => d.ProductType,
                o => o.MapFrom(
                    s => s.ProductType.Name
                )
            )
            .ForMember(
                d => d.Picture,
                o => o.MapFrom<ProductUrlResolver>()
            );
    }
}