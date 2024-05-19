

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class UserEntityConfigartion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x=>x.UserId);
            builder.Property(x => x.UserId).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.HasCheckConstraint("CHK_FirstName", "NOT (FirstName REGEXP '[0-9]') AND NOT (FirstName REGEXP '[^A-Za-z\\s]')");
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.HasCheckConstraint("CHK_LastName", "NOT (LastName REGEXP '[0-9]') AND NOT (LastName REGEXP '[^A-Za-z\\s]')");
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.HasCheckConstraint("Email", "(`Email` like '%@GMAIL%' OR `Email` like '%@HOTMAIL%' OR `Email` like '%@ICLOUD%')");
            builder.Property(x => x.BirthDate).IsRequired();
           //mysql
            builder.HasCheckConstraint("CK_BirthDate", "`BirthDate` <= '2006-01-01'");
           //sql
            // builder.HasCheckConstraint("CK_BirthDate", "AGE(CURRENT_DATE, [BirthDate]) >= interval '18 years'");


            builder.HasMany<UserType>().WithOne().HasForeignKey(x=>x.UsersId);
            builder.HasMany<Login>().WithOne().HasForeignKey(x => x.UsersId);

            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.UsersId);

        }
    }
}

//  builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
//  builder.HasCheckConstraint("Name", "(NOT [Name] like '%[0-9]%' AND NOT [Name] like '%[^A-Za-z ]%')");