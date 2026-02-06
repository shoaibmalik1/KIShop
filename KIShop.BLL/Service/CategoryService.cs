using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using KIShop.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        //public Category CreateCategory(Category Request)
        //{
        //    throw new NotImplementedException();
        //    //var response = categories.Adapt<List<CategoryResponse>>();
        //    var category = Request.Adapt<Category>();
        //    _categoryRepository.Create(category);
        //    return categories.Adapt<CategoryResponse>();
        //}

        //public List<CategoryResponse> GetAllCategories()
        //{
        //    var categories = _categoryRepository.GetAll();
        //    var response = categories.Adapt<List<CategoryResponse>>();
        //    return response;
        //}
        public CategoryResponse CreateCategory(CategoryRequest Request)
        {
            var category = Request.Adapt<Category>();
            //var response = categories.Adapt<List<CategoryResponse>>();
          
            _categoryRepository.Create(category);
            return category.Adapt<CategoryResponse>();
        }

        public List<CategoryResponse> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var response = categories.Adapt<List<CategoryResponse>>();
            return response;
        }
    }
}
