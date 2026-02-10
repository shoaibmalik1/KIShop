using KIShop.DAL.Data;
using KIShop.DAL.DTO.Response;
using KIShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context ) {
            _context = context;
        }

        public async Task<Category>  CreateAsync(Category Request)
        {
           await _context.Categories.AddAsync( Request );
            await _context.SaveChangesAsync();

            return Request;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c=>c.User).Include(c => c.Translations).ToListAsync();

        }
        public async Task<Category?> FindByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Translations)
                .FirstOrDefaultAsync(c => c.Id == id);

        }
      public async  Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }


    }
}
