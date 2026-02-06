using KIShop.BLL.Service;
using KIShop.DAL.Data;
using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using KIShop.DAL.Repository;
using KIShop.PL.Resources;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KIShop.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IStringLocalizer<SharedResource> localizer, ICategoryService CategoryService)
        {

            _localizer = localizer;
            _categoryService = CategoryService;
        }
            [HttpGet("")]
            public IActionResult index()
            {
                var response = _categoryService.GetAllCategories();
                return Ok(new { message = _localizer["Success"].Value, response });
            }

            [HttpPost("")]
            public IActionResult Create(CategoryRequest request)
            {
                var response = _categoryService.CreateCategory(request);
  
                return Ok(new { message = _localizer["Success"].Value });
            }

        }
    }

