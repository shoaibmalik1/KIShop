using KIShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Repository
{
    public interface IProductRepository
    {
        Task<Product>AddAsync(Product request);

        Task<List<Product>> GetAllAsync();

        Task<Product?> FindByIdAsync(int id);

    }
}
