using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjectFinalWebIbrahim_core.Migrations
{
    /// <inheritdoc />
    public partial class te1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategoryId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "longtext", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.CheckConstraint("CHK_FirstName", "NOT (FirstName REGEXP '[0-9]') AND NOT (FirstName REGEXP '[^A-Za-z\\s]')");
                    table.CheckConstraint("CHK_LastName", "NOT (LastName REGEXP '[0-9]') AND NOT (LastName REGEXP '[^A-Za-z\\s]')");
                    table.CheckConstraint("CK_BirthDate", "`BirthDate` <= '2006-01-01'");
                    table.CheckConstraint("Email", "(`Email` like '%@GMAIL%' OR `Email` like '%@HOTMAIL%' OR `Email` like '%@ICLOUD%')");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsHaveDiscount = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.CheckConstraint("CK_DiscountAmount_NonNegative", "`DiscountAmount` >= 0");
                    table.CheckConstraint("CK_Price_NonNegative", "`Price` >= 0");
                    table.CheckConstraint("CK_Quantity_NonNegative", "`Quantity` >= 0");
                    table.ForeignKey(
                        name: "FK_Services_Categorie_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorie",
                        principalColumn: "CategoryId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                    table.CheckConstraint("CK_Password_Complexity", "LENGTH(`Password`) >=  11 AND `Password` REGEXP '%[0-9]%' AND `Password` REGEXP '%[A-Za-z]%' AND `Password` REGEXP '%[^A-Za-z]%'");
                    table.ForeignKey(
                        name: "FK_Login_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "UserId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateOrder = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.CheckConstraint("CK_PaymentMethod_ValidValues", "`PaymentMethod` IN ('CreditCard', 'PayPal', 'BankTransfer')");
                    table.CheckConstraint("CK_Rate_ValidRange", "`Rate` >= 0 AND `Rate` <= 5");
                    table.CheckConstraint("CK_Status_ValidValues", "`Status` IN ('Pending', 'Shipped', 'Delivered', 'Cancelled')");
                    table.ForeignKey(
                        name: "FK_Order_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "UserId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                    table.CheckConstraint("CHK_Name", "NOT (Name REGEXP '[0-9]') AND NOT (Name REGEXP '[^A-Za-z\\s]')");
                    table.ForeignKey(
                        name: "FK_UserType_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "UserId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    OrderServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => x.OrderServiceId);
                    table.ForeignKey(
                        name: "FK_OrderService_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderService_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Login_UsersId",
                table: "Login",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UsersId",
                table: "Order",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_OrderId",
                table: "OrderService",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_ServiceId",
                table: "OrderService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserType_UsersId",
                table: "UserType",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
