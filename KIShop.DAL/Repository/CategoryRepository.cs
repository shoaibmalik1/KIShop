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
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context ) {
            _context = context;
        }

        public Category Create(Category Request)
        {
            _context.Categories.Add( Request );
            _context.SaveChanges();

            return Request;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Translations).ToList();

        }
    }
}
