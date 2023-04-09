using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BIBF.Test.Authorization.Roles;
using BIBF.Test.Authorization.Users;
using BIBF.Test.MultiTenancy;

namespace BIBF.Test.EntityFrameworkCore
{
    public class TestDbContext : AbpZeroDbContext<Tenant, Role, User, TestDbContext>
    {
        public virtual DbSet<Product> Products { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(x =>
            {
                x.HasIndex(e => new { e.TenantId });
            });

            base.OnModelCreating(modelBuilder);


        }

    }
}
