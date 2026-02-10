using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using KIShop.DAL.Repository;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
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


 
        
        public async Task<CategoryResponse> CreateCategory(CategoryRequest Request)
        {
            var category = Request.Adapt<Category>();
        
          
            await _categoryRepository.CreateAsync(category);
            return category.Adapt<CategoryResponse>();
           
        }

        public async Task<List<CategoryResponse>> GetAllCategoriesForAdmin()
        {
            var categories =await _categoryRepository.GetAllAsync();

            var response = categories.Adapt<List<CategoryResponse>>();
            return response;
        }

        public async Task<List<CategoryUserResponse>> GetAllCategoriesForUser(string lang = "en")
        {

            var categories = await _categoryRepository.GetAllAsync();

            var response =categories.BuildAdapter().AddParameters("lang",lang).AdaptToType<List<CategoryUserResponse>>();
            return response;
        }


        public async Task<BaseResponse> UpdateCategoryAsync(int id,CategoryRequest request)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(id);

                if (category is null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Category not found"
                    };
                }
                if (request.Translations!=null)
                {
                    foreach(var translation in request.Translations)
                    {
                        var existing = category.Translations.FirstOrDefault(t => t.Language == translation.Language);

                        if (existing != null) 
                        {
                            existing.Name = translation.Name;
                        }
                        else
                        {
                            category.Translations.Add(new CategoryTranslation
                            {
                                Name=translation.Name,
                                Language=translation.Language

                            });
                        }

                     
                    }
                  
                }

                await _categoryRepository.UpdateAsync(category);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Category Updated Successfuly "
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "cant delete Category ",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        public async Task<BaseResponse> ToggleStatus(int id)
        {
            try 
            {
                var category = await _categoryRepository.FindByIdAsync(id);

                if (category is null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Category not found"
                    };
                }

                category.Status = category.Status == Status.Active ? Status.inActive : Status.Active;
                await _categoryRepository.UpdateAsync(category);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Category Updated Successfuly "
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "cant delete Category ",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        public async Task<BaseResponse> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.FindByIdAsync(id);

                if (category is null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Category not found"
                    };
                }
                await _categoryRepository.DeleteAsync(category);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Category Deleted Successfuly"
                };
            }
            catch (Exception ex) 
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "cant delete Category ",
                    Errors=new List<string> { ex.Message }
                };
            }
         }


    }
}
