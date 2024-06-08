
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

            builder.Property(x => x.IsِActive).IsRequired();
            builder.Property(x => x.IsِActive).HasDefaultValue(false);


            /*   builder.Property(e => e.UserId)
                   .IsRequired(false);*/

            //سوال هون كيف اعمل تححقق اذ كانت في طلب مايعبي جدول مستخدم والهعكس
            builder.Property(e => e.OrderId)
                .IsRequired(false);

            builder.HasOne<Problem>().WithMany().HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.SetNull);

            //  builder.HasMany<Problem>().WithOne().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.SetNull);
            //  builder.HasOne<User>().WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.SetNull);

            // builder.HasMany<Problem>().WithOne().HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.SetNull);


        }
    }
}
