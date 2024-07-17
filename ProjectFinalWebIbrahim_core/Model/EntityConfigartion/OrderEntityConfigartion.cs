

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class OrderEntityConfigartion : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.HasKey(o => o.OrderId);

         
            builder.Property(o => o.OrderId)
                   .ValueGeneratedOnAdd();

           
            builder.Property(o => o.DateOrder)
                   .IsRequired();

            //communit3
           // builder.ToTable(x => x.HasCheckConstraint("CK_DateOrder_NotInFuture", "`DateOrder` <= CURDATE()"));

            builder.Property(o => o.Title)
                   .HasMaxLength(100) 
                   .IsRequired();     

            builder.Property(o => o.Note)
                   .HasMaxLength(500); 

      
           // builder.Property(o => o.PaymentMethod)
            //       .HasMaxLength(100);
            //communit2
           // builder.ToTable(x => x.HasCheckConstraint("CK_PaymentMethod_ValidValues", "`PaymentMethod` IN ('CreditCard', 'PayPal', 'Cash')"));

            builder.Property(o => o.Status)
                   .HasMaxLength(50) 
                   .IsRequired();

            //communit1
         //   builder.ToTable(x => x.HasCheckConstraint("CK_Status_ValidValues", "`Status` IN ('Pending', 'Shipped', 'Delivered', 'Cancelled')"));

            builder.Property(o => o.Rate)
                   .IsRequired()  
                   .HasDefaultValue(0);
            builder.ToTable(x => x.HasCheckConstraint("CK_Rate_ValidRange", "`Rate` >= 0 AND `Rate` <= 5"));
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired(false);

            builder.Property(x => x.IsِActive).IsRequired();
            builder.Property(x => x.IsِActive).HasDefaultValue(false);
        }
    }
}
