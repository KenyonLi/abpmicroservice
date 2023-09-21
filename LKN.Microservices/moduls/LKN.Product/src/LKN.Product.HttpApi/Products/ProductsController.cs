using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;

namespace LKN.Product.Products
{
    [RemoteService]
    [Route("api/ProductService/product")]
    public class ProductsController : ProductController, IProductAppService
    {
        private readonly IProductAppService _ProductAppService;

        public ProductsController(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetAsync(Guid id)
        {
            return await _ProductAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            return await _ProductAppService.CreateAsync(input);
        }

        [HttpGet]
        public Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return  _ProductAppService.GetListAsync(input);
        }

        [HttpPut]
        public Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("ProductAndImages")]
        public List<ProductDto> GetProductAndImages()
        {
            throw new NotImplementedException();
        }

        [HttpGet("ProductByAttr")]
        public IEnumerable<ProductDto> GetProductByAttr(ProductAttrQueryDto createProductDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("ProductTotals")]
        public ProductTotaLDto GetProductTotals()
        {
            throw new NotImplementedException();
        }

        [HttpGet("GetProductAndImage")]
        public IEnumerable<ProductDto> GetProductAndImage()
        {
            throw new NotImplementedException();
        }
    }
}
