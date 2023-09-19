using Volo.Abp.Application.Dtos;

namespace LKN.Product.Products
{
    public class ProductNameQueryDto : PagedAndSortedResultRequestDto
    {
        public string ProductName { set; get; }
    }
}
