using KIShop.BLL.Service;
using KIShop.DAL.DTO.Request;
using KIShop.PL.Resources;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KIShop.PL.Areas.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ProductsController(
            IProductService productService,
            IStringLocalizer<SharedResource> localizer)
        {
            _productService = productService;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]ProductRequest request) 
        {
            var response = _productService.CreateProduct(request);
            return Ok(new { message = _localizer["Product is Added Successfully"].Value,response });
        }

      
        }
}
