using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace LKN.Product.Products
{
    /// <summary>
    /// 禁止 ABP 默认的生成的API接口，创建、添加、查询
    /// </summary>
    [RemoteService(IsEnabled = false)]
    [Dependency(ServiceLifetime.Singleton)]
    public class ProductAppService : CrudAppService<
        Product,
        ProductDto, 
        Guid,
        PagedAndSortedResultRequestDto,
        CreateProductDto, 
        UpdateProductDto>, IProductAppService,
        ICapSubscribe
    {
        //public IProductAbpRepository _productAbpRepository;
        public IBlobContainer _blobContainer { set; get; } // 存储文件到Minio
        /// <summary>
        /// 
        /// </summary>
        public IProductMongoDBRepository _productAbpRepository { set; get; }//  选择MongoDB
        /// <summary>
        /// MongoDB 和 EF 只能选择一个，使用时，需要修改
        /// </summary>
        /// <param name="repository"></param>
        public ProductAppService(IProductMongoDBRepository repository) : base(repository)
        {
            _productAbpRepository = repository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductDto> Update2Async(UpdateProductDto input)
        {
            return await this.UpdateAsync(input.Id,input);
        }

        /// <summary>
        /// 接受创建订单的事件
        /// </summary>
        /// <param name="createOrderDto"></param>
        //[CapSubscribe("OrderService.CreateOrder")]
        public void CreateOrderEvent(string dddd)
        {
            Console.WriteLine($"创建订单：{dddd}");
            // throw new Exception("创建订单失败");
            //var orderDto = this.CreateAsync(createOrderDto).Result;
            Console.WriteLine($"创建成功：{dddd}");
        }

        // [RemoteService(IsEnabled = false)]
        public IEnumerable<ProductDto> GetProductAndImage()
        {
            // 1、查询所有和图片
            IEnumerable<Product> products = _productAbpRepository.GetProductAndImages();

            // 2、然后映射
            return ObjectMapper.Map<IEnumerable<Product>, List<ProductDto>>(products);
        }
        //[RemoteService(IsEnabled = false)]
        public IEnumerable<ProductDto> GetProductByAttr(ProductAttrQueryDto createProductDto)
        {
            // 1、查询所有和图片
            // IEnumerable<Product> products = _productAbpRepository.GetProductByName(createProductDto.productName);

            // 2、然后映射
            //return ObjectMapper.Map<IEnumerable<Product>, List<ProductDto>>(products);

            return null;
        }

        public ProductTotaLDto GetProductTotals()
        {
            throw new NotImplementedException();
        }


        public async Task SaveOrderPictrueAsync(IFormFile formFile)
        {
            // 1、保存商品图片到Minio
            await _blobContainer.SaveAsync(formFile.FileName, formFile.OpenReadStream(), true); // true就是覆盖
            // 1、删除
            // 2、查询 stream  oss 系统
            //_blobContainer.SaveAsync
        }

    }
}
