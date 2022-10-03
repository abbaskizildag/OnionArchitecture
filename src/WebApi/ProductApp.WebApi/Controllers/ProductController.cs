using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRespository productRespository;
        public ProductController(IProductRespository productRespository)
        {
            this.productRespository = productRespository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allList = await productRespository.GetAllAsync();

            var result = allList.Select(i => new ProductViewDto()
            {
                Id = i.Id,
                Name = i.Name,
            });

            return Ok(result);
        }
    }
}
