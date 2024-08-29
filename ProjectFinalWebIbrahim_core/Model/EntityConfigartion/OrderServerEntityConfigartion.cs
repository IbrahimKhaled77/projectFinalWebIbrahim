/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFinalWebIbrahim_core.Model.Entity;


namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class OrderServerEntityConfigartion : IEntityTypeConfiguration<OrderService>
    {
        public void Configure(EntityTypeBuilder<OrderService> builder )
        {
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired(false);

            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasKey(l => l.OrderServiceId);


            builder.Property(l => l.OrderServiceId)
                   .ValueGeneratedOnAdd();

            builder.HasOne<Order>().WithMany().HasForeignKey(os => os.OrderId);


            builder.HasOne<Service>().WithMany().HasForeignKey(os => os.ServiceId);

            



        }
    }
}
*/