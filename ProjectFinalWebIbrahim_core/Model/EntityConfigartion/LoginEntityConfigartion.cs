
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectFinalWebIbrahim_core.Model.Entity;

namespace ProjectFinalWebIbrahim_core.Model.EntityConfigartion
{
    public class LoginEntityConfigartion : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            
            builder.HasKey(l => l.LoginId);

            
            builder.Property(l => l.LoginId)
                   .ValueGeneratedOnAdd();
 

            builder.Property(l => l.UserName)
                   .HasMaxLength(50) 
                   .IsRequired();


            builder.Property(l => l.Password)
                   .HasMaxLength(100) 
                   .IsRequired();

            builder.ToTable(x => x.HasCheckConstraint("CK_Password_Complexity", "LENGTH(`Password`) >= 11 AND `Password` REGEXP '[0-9]' AND `Password` REGEXP '[A-Za-z]' AND `Password` REGEXP '[^A-Za-z0-9]'"));

            builder.Property(l => l.LastLoginTime)
                  .IsRequired(false); 


            builder.Property(l => l.IsLoggedIn)
                   .IsRequired()  
                   .HasDefaultValue(false); // Set a default value of false for the IsLoggedIn property

            builder.Property(x => x.CreationDate).IsRequired();

            

            builder.Property(x => x.IsِActive).IsRequired();
            builder.Property(x => x.IsِActive).HasDefaultValue(false);

        }
    }
}
