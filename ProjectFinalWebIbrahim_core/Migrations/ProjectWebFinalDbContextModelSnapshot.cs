﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectFinalWebIbrahim_core.Context;

#nullable disable

namespace ProjectFinalWebIbrahim_core.Migrations
{
    [DbContext(typeof(ProjectWebFinalDbContext))]
    partial class ProjectWebFinalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("DescriptionArabic")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TitleArabic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("imageTitleCategory")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsLoggedIn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("LoginId");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("Login", t =>
                        {
                            t.HasCheckConstraint("CK_Password_Complexity", "LENGTH(`Password`) >= 11 AND `Password` REGEXP '[0-9]' AND `Password` REGEXP '[A-Za-z]' AND `Password` REGEXP '[^A-Za-z0-9]'");
                        });
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address2")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal?>("priceFinal2")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UsersId");

                    b.ToTable("Order", t =>
                        {
                            t.HasCheckConstraint("CK_Rate_ValidRange", "`Rate` >= 0 AND `Rate` <= 5");
                        });
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PaymentMethodId");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProblemId");

                    b.HasIndex("UserId");

                    b.ToTable("Problem");
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("DescriptionArabic")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DiscountType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsHaveDiscount")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceAfterDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityUnit")
                        .HasColumnType("int");

                    b.Property<string>("TitleArabic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("imagetitleservice")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ServiceId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Services", t =>
                        {
                            t.HasCheckConstraint("CK_DiscountPrice_NonNegative", "`DiscountPrice` >= 0");

                            t.HasCheckConstraint("CK_Price_NonNegative", "`Price` >= 0");
                        });
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageProfile")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User", t =>
                        {
                            t.HasCheckConstraint("CHK_FirstName", "NOT (FirstName REGEXP '[0-9]') AND NOT (FirstName REGEXP '[^A-Za-z\\s]')");

                            t.HasCheckConstraint("CHK_LastName", "NOT (LastName REGEXP '[0-9]') AND NOT (LastName REGEXP '[^A-Za-z\\s]')");

                            t.HasCheckConstraint("CK_BirthDate", "`BirthDate` <= '2006-01-01'");

                            t.HasCheckConstraint("CK_Phone", "`Phone` LIKE '00962%' AND LENGTH(`Phone`) = 14 AND `Phone` REGEXP '^[0-9]+$'");

                            t.HasCheckConstraint("Email", "(`Email` like '%@GMAIL%' OR `Email` like '%@HOTMAIL%' OR `Email` like '%@ICLOUD%')");
                        });
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Login", b =>
                {
                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("ProjectFinalWebIbrahim_core.Model.Entity.Login", "UsersId");
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Order", b =>
                {
                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.PaymentMethod", b =>
                {
                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("ProjectFinalWebIbrahim_core.Model.Entity.PaymentMethod", "UsersId");
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Problem", b =>
                {
                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("ProjectFinalWebIbrahim_core.Model.Entity.Service", b =>
                {
                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("ProjectFinalWebIbrahim_core.Model.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
