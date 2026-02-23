using KIShop.DAL.Data;
using KIShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product request)
        {
            //الكود
              await _context.AddAsync(request);
               _context.SaveChanges();
        return request;
        }
    }
}
