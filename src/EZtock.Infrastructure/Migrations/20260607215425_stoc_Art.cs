using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EZtock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class stoc_Art : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Stock",
                schema: "public",
                table: "Articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "public",
                table: "Articles");
        }
    }
}
