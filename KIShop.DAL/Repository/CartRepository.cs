using Azure.Core;
using KIShop.DAL.Data;
using KIShop.DAL.Migrations;
using KIShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDBContext _context;

        public CartRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Cart> CreateAsync(Cart Request)
        {
            await _context.AddAsync(Request);
            await _context.SaveChangesAsync();

            return Request;
        }
    }
}
