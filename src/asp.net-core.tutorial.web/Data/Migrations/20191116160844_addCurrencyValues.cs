using Microsoft.EntityFrameworkCore.Migrations;

namespace asp.net_core.tutorial.web.Data.Migrations
{
    public partial class addCurrencyValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "ShortCode" },
                values: new object[] { 1, "Romanian New Leu", "RON" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "ShortCode" },
                values: new object[] { 2, "EU currency", "EUR" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "ShortCode" },
                values: new object[] { 3, "United States Dolar", "USD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
