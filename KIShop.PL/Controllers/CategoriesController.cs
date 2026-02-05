using KIShop.DAL.Data;
using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
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
        private readonly ApplicationDBContext _context;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategoriesController(ApplicationDBContext context,IStringLocalizer<SharedResource> localizer)
        {
          _context = context;
          _localizer = localizer;
        }
        [HttpGet("")]
        public IActionResult index()
        {
            var categories = _context.Categories.Include(c=>c.Translations).ToList();
            var response = categories.Adapt<List<CategoryResponse>>();
            return Ok(new {message= _localizer["Success"].Value, response });
        }

        [HttpPost("")]
        public IActionResult Create(CategoryRequest request)
        {
            var category =request.Adapt<Category>();
            _context.Add(category);
            _context.SaveChanges();
            return Ok(new { message = _localizer["Success"].Value });
        }

    }
}
