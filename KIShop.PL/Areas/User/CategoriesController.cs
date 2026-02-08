using KIShop.BLL.Service;
using KIShop.DAL.DTO.Request;
using KIShop.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KIShop.PL.Areas.User
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
     
      
       

            private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ICategoryService _category;

        public CategoriesController(IStringLocalizer<SharedResource> localizer, ICategoryService category)
            {

                _localizer = localizer;
            _category = category;
        }
            [HttpGet("")]
            public IActionResult index()
            {
                var response = _category.GetAllCategories();
                return Ok(new { message = _localizer["Success"].Value, response });
            }
      

        }
    }
