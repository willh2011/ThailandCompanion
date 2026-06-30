using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThailandCompanion.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProvinceEntityFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nameth",
                table: "Provinces",
                newName: "NameTh");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Provinces",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Provinces",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameTh",
                table: "Provinces",
                newName: "Nameth");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Provinces",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Provinces",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
