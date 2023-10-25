using LKN.EbusinessWebSite.Models;
using LKN.Order.Orders;
using LKN.Product.Products;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LKN.EbusinessWebSite.Controllers
{
     
        /// <summary>
        /// 电商网站首页
        /// </summary>
        //[Authorize]
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;

            public IProductAppService _ProductAppService { set; get; }
            public IOrderAppService _OrderAppService { set; get; } // 动态C#客户端

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            /// <summary>
            /// 电商网站首页
            /// </summary>
            /// <returns></returns>
            [Authorize]
            public IActionResult Index()
            {
                string access_token = HttpContext.GetTokenAsync("access_token").Result;

                // 1、查询订单
                OrderDto orderDto = _OrderAppService.GetAsync(Guid.Parse("3a0e6eae-951c-2256-cbf5-31385f879458")).Result;

                /*// 2、查询商品
                OrderItemDto[] orderItemDtos = orderDto.OrderItems;
                foreach (var orderItem in orderItemDtos)
                {
                    ProductDto productDto = _ProductAppService.GetAsync(orderItem.ProductId).Result;

                    //3、设置商品名称
                    orderItem.ProductName = productDto.ProductTitle;
                }*/
                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
}