using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Servicecomb.Saga.Omega.Abstractions.Transaction;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using LKN.Microservices.Infrastructure.Redis;

namespace LKN.Product.Products
{
    [RemoteService]
    [Route("api/ProductService/Product")]
    public class ProductsController : ProductController, IProductAppService
    {
        private readonly IProductAppService _ProductAppService;
        public IDistributedCache<ProductDto> _distributedCache { set; get; } // 使用redis
        public ProductsController(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }
        /// <summary>
        /// 查询商品API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ProductDto> GetAsync(Guid id)
        {
            ProductDto productDto = await _distributedCache.GetAsync(id.ToString());
            if (productDto == null)
            {
                productDto = await _ProductAppService.GetAsync(id);
                await _distributedCache.SetAsync(id.ToString(), productDto, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60) // 设置过期时间
                });
            }
            return productDto;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        {
            //throw new Exception("扣减库存失败");
            #region 1、传统
            {
                /* ProductDto productDto = await _ProductAppService.UpdateAsync(id, input);*/
            }
            #endregion

            #region 2、分布式锁(多实例)
            {
                RedisLock redisLock = new RedisLock();
                redisLock.Lock();
                ProductDto productDto = await _ProductAppService.UpdateAsync(id, input);
                redisLock.UnLock();
                return productDto;
            }
            #endregion

            #region 2、线程锁(单实例)
            {
                /*lock ()
                {
                    ProductDto productDto = await _ProductAppService.UpdateAsync(id, input);
                }
                
                return productDto;*/
            }
            #endregion
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
        ///// <summary>
        ///// 更新方法接受
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPut/*, Compensable(nameof(RecoverStock))*/]
        //public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductDto input)
        //{
        //    return await _ProductAppService.UpdateAsync(id, input);
        //}
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
            return _ProductAppService.GetListAsync(input);
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

        /// <summary>
        /// 上传图片接口
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("SaveOrderPictrue")]
        public Task SaveOrderPictrueAsync(IFormFile formFile)
        {
            return _ProductAppService.SaveOrderPictrueAsync(formFile);
        }
    }
}
