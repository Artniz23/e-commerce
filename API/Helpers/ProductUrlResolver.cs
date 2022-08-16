using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class ProductUrlResolver : IValueResolver<Product, ProductResponseDto, string>
{
    private readonly IConfiguration _config;
    
    public ProductUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.Picture))
        {
            return _config["ApiUrl"] + source.Picture;
        }

        return null;
    }
}