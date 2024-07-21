using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFinalWebIbrahim_core.Migrations
{
    /// <inheritdoc />
    public partial class b3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priceFinal",
                table: "OrderService");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "priceFinal",
                table: "OrderService",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
