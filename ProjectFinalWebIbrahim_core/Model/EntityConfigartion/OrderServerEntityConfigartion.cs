
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFinalWebIbrahim_core.Model.Entity;
using System.Reflection.Emit;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class OrderServerEntityConfigartion : IEntityTypeConfiguration<OrderService>
    {
        public void Configure(EntityTypeBuilder<OrderService> builder )
        {

            builder.HasKey(l => l.OrderServiceId);


            builder.Property(l => l.OrderServiceId)
                   .ValueGeneratedOnAdd();

            builder.HasOne<Order>().WithMany().HasForeignKey(os => os.OrderId);


            builder.HasOne<Service>().WithMany().HasForeignKey(os => os.ServiceId);

            



        }
    }
}
