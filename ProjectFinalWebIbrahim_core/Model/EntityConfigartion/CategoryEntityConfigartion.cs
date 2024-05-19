
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class CategoryEntityConfigartion : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId)
                   .ValueGeneratedOnAdd();


            builder.Property(c => c.Title)
                   .HasMaxLength(100)
                   .IsRequired();
       

            builder.Property(c => c.Description)
                   .HasMaxLength(500);


            builder.HasMany<Service>().WithOne().HasForeignKey(x => x.CategoryId);
        }
    }
}
