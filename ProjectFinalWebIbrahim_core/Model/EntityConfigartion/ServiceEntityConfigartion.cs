

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

            builder.Property(s => s.TitleArabic)
          .HasMaxLength(100)
          .IsRequired();


            builder.Property(s => s.DescriptionArabic)
                   .HasMaxLength(500);


            builder.Property(s => s.Description)
                   .HasMaxLength(500); 

          
            builder.Property(s => s.imagetitleservice)
                   .HasMaxLength(200);

      
        builder.Property(s => s.Price)
                   .HasColumnType("decimal(18,2)"); // Set the precision and scale for the Price property
            builder.ToTable(x => x.HasCheckConstraint("CK_Price_NonNegative", "`Price` >= 0"));

            builder.Property(s => s.QuantityUnit)
                   .IsRequired(); 



            builder.Property(s => s.IsHaveDiscount)
                   .IsRequired()  
                   .HasDefaultValue(false); // Set a default value of false for the IsHaveDiscount property

         
            builder.Property(s => s.DiscountPrice)
                   .HasColumnType("decimal(18,2)");
            builder.ToTable(x => x.HasCheckConstraint("CK_DiscountPrice_NonNegative", "`DiscountPrice` >= 0"));


            builder.Property(s => s.DiscountType)
                   .HasMaxLength(50);

            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired(false);

            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.ServiceId);
        }
    }
}
