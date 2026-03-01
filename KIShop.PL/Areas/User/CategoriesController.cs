using KIShop.BLL.Service;
using KIShop.DAL.DTO.Request;
using KIShop.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

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
            public async Task<IActionResult> index([FromQuery]string lang="en")
            {
                var response =await _category.GetAllCategoriesForUser(lang);
                return Ok(new { message = _localizer["Success"].Value, response });
            }
      

        }
    }
