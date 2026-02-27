using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.BLL.Service
{
    public interface IProductService
    {
        Task<ProductResponse> CreateProduct(ProductRequest request);

        Task<List<ProductResponse>> GetAllProductsForAdmin();

        Task<List<ProductUserResponse>> GetAllProductsForUser(string lang = "en");

        Task<ProductUserDetails> GetAllProductsDetailsForUser(int id, string lang = "en");
    }
}
