using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.BLL.Service
{
    public interface ICategoryService
    {
        List<CategoryResponse> GetAllCategories();

        CategoryResponse CreateCategory(CategoryRequest Request);

    }
}
