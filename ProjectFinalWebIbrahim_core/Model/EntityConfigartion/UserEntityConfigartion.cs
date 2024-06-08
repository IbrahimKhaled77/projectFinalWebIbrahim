

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFinalWebIbrahim_core.Model.Entity;
using System.Reflection.Emit;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class UserEntityConfigartion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x=>x.UserId);
            builder.Property(x => x.UserId).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("CHK_FirstName", "NOT (FirstName REGEXP '[0-9]') AND NOT (FirstName REGEXP '[^A-Za-z\\s]')"));
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("CHK_LastName", "NOT (LastName REGEXP '[0-9]') AND NOT (LastName REGEXP '[^A-Za-z\\s]')"));
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("Email", "(`Email` like '%@GMAIL%' OR `Email` like '%@HOTMAIL%' OR `Email` like '%@ICLOUD%')"));
            builder.Property(x => x.BirthDate).IsRequired();
            //mysql
            builder.ToTable(x => x.HasCheckConstraint("CK_BirthDate", "`BirthDate` <= '2006-01-01'"));

            builder.Property(x => x.Phone).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("CK_Phone", "`Phone` LIKE '00962%' AND LENGTH(`Phone`) = 14 AND `Phone` REGEXP '^[0-9]+$'"));


            builder.Property(x => x.CreationDate).IsRequired();
            
            builder.Property(x => x.ModifiedDate).IsRequired(false);
           
            builder.Property(x => x.IsِActive).IsRequired();
            builder.Property(x => x.IsِActive).HasDefaultValue(false);

            
            builder.HasOne<Login>().WithOne().HasForeignKey<Login>(x => x.UsersId);
           

            builder.HasMany<Service>().WithOne().HasForeignKey(x => x.UserId);

            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.UsersId);

        }
    }
}
//sql
// builder.HasCheckConstraint("CK_BirthDate", "AGE(CURRENT_DATE, [BirthDate]) >= interval '18 years'");
//  builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
//  builder.HasCheckConstraint("Name", "(NOT [Name] like '%[0-9]%' AND NOT [Name] like '%[^A-Za-z ]%')");