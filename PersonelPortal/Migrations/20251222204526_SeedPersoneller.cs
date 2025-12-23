using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonelPortal.Migrations
{
    /// <inheritdoc />
    public partial class SeedPersoneller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "AdSoyad", "Birim", "Telefon", "Unvan" },
                values: new object[,]
                {
                    { 1, "Samet Becene", "Donanım Şube", "0537 279 2807", "Teknik Destek Uzmanı" },
                    { 2, "Çağrı Arısoy", "Yazılım Geliştirme Şubesi", "0500 111 11 11", "Yazılımcı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
