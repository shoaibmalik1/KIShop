using KIShop.BLL.Service;
using KIShop.DAL.DTO.Request;
using KIShop.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KIShop.PL.Areas.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {

        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ICategoryService _category;

        public CategoriesController(IStringLocalizer<SharedResource> localizer, ICategoryService category)
        {

            _localizer = localizer;
            _category = category;
        }

        [HttpPost("")]
        public IActionResult Create(CategoryRequest request)
        {
            var response = _category.CreateCategory(request);
            return Ok(new { message = _localizer["Success"].Value });
        }
    }
}
