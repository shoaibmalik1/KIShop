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
        Task<List<CategoryResponse>> GetAllCategories();

        Task<CategoryResponse> CreateCategory(CategoryRequest Request);

        Task<BaseResponse> DeleteCategoryAsync(int id);

        Task<BaseResponse> UpdateCategoryAsync(int id, CategoryRequest request);

        Task<BaseResponse> ToggleStatus(int id);

    }
}
