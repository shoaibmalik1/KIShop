using KIShop.DAL.Migrations;
using KIShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Repository
{
    public interface ICartRepository
    {
        Task<Cart> CreateAsync(Cart Request);
    }
}
