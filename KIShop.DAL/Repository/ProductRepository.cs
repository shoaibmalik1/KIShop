using KIShop.DAL.Data;
using KIShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.products.Include(c => c.User).Include(c => c.Translations).ToListAsync();

        }
        public async Task<Product> AddAsync(Product request)
        {
            //الكود
              await _context.AddAsync(request);
               _context.SaveChanges();
        return request;
        }
        public async Task<Product?> FindByIdAsync(int id)
        {
            //الكود
            return await _context.products.Include(c => c.Translations)
                      .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
