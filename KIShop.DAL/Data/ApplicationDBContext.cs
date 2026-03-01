using KIShop.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Data
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> categoryTranslation { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductTranslation> productTranslation { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Cart>carts { get; set; }

       

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options,
           IHttpContextAccessor httpContextAccessor)
        : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.Entity<Category>().HasOne(c=>c.User)
                .WithMany().HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);
          
            builder.Entity<Cart>().HasOne(c=>c.User)
                .WithMany().HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Product>()
    .Property(p => p.Price)
    .HasPrecision(18, 2);

            builder.Entity<Product>()
                .Property(p => p.Discount)
                .HasPrecision(18, 2);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseModel>();


            if(_httpContextAccessor.HttpContext!= null)
            {
            var cerrentUserId = _httpContextAccessor.HttpContext.
                User.FindFirstValue(ClaimTypes.NameIdentifier);

           
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(x => x.CreatedBy).CurrentValue = cerrentUserId;
                    entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(x => x.UpdatedBy).CurrentValue = cerrentUserId;
                    entityEntry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }


            }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var entries =ChangeTracker.Entries<BaseModel>();

            var cerrentUserId = _httpContextAccessor.HttpContext.
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(x=>x.CreatedBy).CurrentValue= cerrentUserId;
                    entityEntry.Property(x=>x.CreatedAt).CurrentValue= DateTime.UtcNow;
                }else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(x => x.UpdatedBy).CurrentValue = cerrentUserId;
                    entityEntry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }
            
                
            }

            return base.SaveChanges();
        }
    }
}
