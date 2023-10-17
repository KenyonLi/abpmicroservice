using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Servicecomb.Saga.Omega.Abstractions.Transaction;

namespace LKN.Product.Products
{
    [RemoteService]
    [Route("api/ProductService/Product")]
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


        /// <summary>
        /// 更新方法接受
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("Update2Async")]
        public async Task<ProductDto> Update2Async(UpdateProductDto input)
        {
            return await _ProductAppService.Update2Async(input);
        }
        /// <summary>
        /// 更新方法接受
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Compensable(nameof(RecoverStock))]
        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        {
            return await _ProductAppService.UpdateAsync(id, input);
        }
        /// <summary>
        /// 恢复库存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        void RecoverStock(UpdateProductDto input)
        {
            Console.WriteLine("恢复商品库存");
            input.ProductStock = 10;
            _ProductAppService.UpdateAsync(input.Id, input).Wait();
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


        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
            return _ProductAppService.DeleteAsync(id);
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
