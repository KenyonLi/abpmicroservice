using AutoMapper;
using Volo.Abp.Application.Dtos;

namespace LKN.Product;

public class ProductApplicationAutoMapperProfile : Profile
{
    public ProductApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<PagedAndSortedResultRequestDto, LKN.Product.Products.Product>();
        CreateMap<LKN.Product.Products.CreateProductDto, LKN.Product.Products.Product>();
        CreateMap<LKN.Product.Products.UpdateProductDto, LKN.Product.Products.Product>();
        CreateMap<LKN.Product.Products.ProductAttrQueryDto, LKN.Product.Products.Product>();
        CreateMap<LKN.Product.Products.ProductImageDto, LKN.Product.Products.ProductImage>();

        CreateMap<LKN.Product.Products.Product, LKN.Product.Products.ProductDto>();
        CreateMap<LKN.Product.Products.ProductImage, LKN.Product.Products.ProductImageDto>();
        CreateMap<LKN.Product.Products.ProductImageCreateDto, LKN.Product.Products.ProductImage>();
    }
}
