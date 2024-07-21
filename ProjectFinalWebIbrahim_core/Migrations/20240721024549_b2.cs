using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFinalWebIbrahim_core.Migrations
{
    /// <inheritdoc />
    public partial class b2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "priceFinal",
                table: "OrderService",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "priceFinal2",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderService");

            migrationBuilder.DropColumn(
                name: "priceFinal",
                table: "OrderService");

            migrationBuilder.DropColumn(
                name: "priceFinal2",
                table: "Order");
        }
    }
}
