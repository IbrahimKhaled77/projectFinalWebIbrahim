

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class ServiceEntityConfigartion : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            
            builder.HasKey(s => s.ServiceId);

           
            builder.Property(s => s.ServiceId)
                   .ValueGeneratedOnAdd();

         
            builder.Property(s => s.Name)
                   .HasMaxLength(100) 
                   .IsRequired();    

    
            builder.Property(s => s.Description)
                   .HasMaxLength(500); 

          
            builder.Property(s => s.Image)
                   .HasMaxLength(200); 

         
            builder.Property(s => s.Price)
                   .HasColumnType("decimal(18,2)"); // Set the precision and scale for the Price property
            builder.HasCheckConstraint("CK_Price_NonNegative", "`Price` >= 0");

            builder.Property(s => s.Quantity)
                   .IsRequired()  
                   .HasDefaultValue(0); // Set a default value of 0 for the Quantity property

            builder.HasCheckConstraint("CK_Quantity_NonNegative", "`Quantity` >= 0");

            builder.Property(s => s.IsHaveDiscount)
                   .IsRequired()  
                   .HasDefaultValue(false); // Set a default value of false for the IsHaveDiscount property

         
            builder.Property(s => s.DiscountAmount)
                   .HasColumnType("decimal(18,2)");
            builder.HasCheckConstraint("CK_DiscountAmount_NonNegative", "`DiscountAmount` >= 0");


            builder.Property(s => s.DiscountType)
                   .HasMaxLength(50);


           
        }
    }
}
