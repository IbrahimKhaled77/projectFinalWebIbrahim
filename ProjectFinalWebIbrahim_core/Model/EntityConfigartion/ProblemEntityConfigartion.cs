
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class ProblemEntityConfigartion:IEntityTypeConfiguration<Problem>
    {

    

        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.HasKey(l => l.ProblemId);


            builder.Property(l => l.ProblemId).ValueGeneratedOnAdd();

            builder.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(100);

            builder.Property(e => e.Purpose)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired(false);

            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);


        
            builder.Property(e => e.UserId)
                .IsRequired(false);



        }
    }
}
