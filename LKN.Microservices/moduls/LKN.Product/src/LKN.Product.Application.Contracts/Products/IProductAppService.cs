using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LKN.Product.Products
{
    /// <summary>
    /// 商品服务
    /// </summary>
    public interface IProductAppService:ICrudAppService<ProductDto,Guid,PagedAndSortedResultRequestDto,CreateProductDto,UpdateProductDto>
    {
        public IEnumerable<ProductDto> GetProductAndImage();

        public IEnumerable<ProductDto> GetProductByAttr(ProductAttrQueryDto createProductDto);

        public ProductTotaLDto GetProductTotals();


        public  Task<ProductDto> Update2Async(UpdateProductDto input);

        public  Task SaveOrderPictrueAsync(IFormFile formFile);

    }
}
