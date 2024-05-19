

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class UserTypeEntityConfigartion : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(u => u.UserTypeId);
            builder.Property(x => x.UserTypeId).ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasCheckConstraint("CHK_Name", "NOT (Name REGEXP '[0-9]') AND NOT (Name REGEXP '[^A-Za-z\\s]')");
        }
    }
}
