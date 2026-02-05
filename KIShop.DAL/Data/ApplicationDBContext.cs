using KIShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Data
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> categoryTranslation { get; set; }
       

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        { 
        
        } 

    }
}
