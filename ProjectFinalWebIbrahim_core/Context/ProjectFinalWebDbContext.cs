

using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Model.Entity;
using ProjectFinalWebIbrahim_core.Model.EntityConfigartion;

namespace ProjectFinalWebIbrahim_core.Context
{
    public class ProjectWebFinalDbContext : DbContext
    {
        public ProjectWebFinalDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.ApplyConfiguration(new UserEntityConfigartion());
         
            modelBuilder.ApplyConfiguration(new LoginEntityConfigartion());
            modelBuilder.ApplyConfiguration(new ServiceEntityConfigartion());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfigartion());
            modelBuilder.ApplyConfiguration(new OrderEntityConfigartion());
            modelBuilder.ApplyConfiguration(new ProblemEntityConfigartion());

            modelBuilder.Entity<PaymentMethod>().HasKey(x => x.PaymentMethodId);
            modelBuilder.Entity<PaymentMethod>().Property(x => x.PaymentMethodId).UseIdentityColumn();
        }


        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Category> Categorie { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        
        public virtual DbSet<Problem> Problem { get; set; }
    }
}
