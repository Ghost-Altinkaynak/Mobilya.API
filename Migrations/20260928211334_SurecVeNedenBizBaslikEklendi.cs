using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moilya.API.Migrations
{
    /// <inheritdoc />
    public partial class SurecVeNedenBizBaslikEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NedenBizBasligi",
                table: "AnaSayfaMansetleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurecAciklamasi",
                table: "AnaSayfaMansetleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurecBasligi",
                table: "AnaSayfaMansetleri",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NedenBizBasligi",
                table: "AnaSayfaMansetleri");

            migrationBuilder.DropColumn(
                name: "SurecAciklamasi",
                table: "AnaSayfaMansetleri");

            migrationBuilder.DropColumn(
                name: "SurecBasligi",
                table: "AnaSayfaMansetleri");
        }
    }
}
