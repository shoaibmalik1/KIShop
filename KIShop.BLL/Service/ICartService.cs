using KIShop.DAL.DTO.Request;
using KIShop.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.BLL.Service
{
    public interface ICartService
    {
        Task<BaseResponse> AddToCartAsync(string userId, AddToCartRequest request);
    }
}
