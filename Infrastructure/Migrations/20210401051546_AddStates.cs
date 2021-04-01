using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatesDb",
                columns: new[] { "Id", "Description", "State" },
                values: new object[] { 1, "Arizona", "AZ" });

            migrationBuilder.InsertData(
                table: "StatesDb",
                columns: new[] { "Id", "Description", "State" },
                values: new object[] { 2, "California", "CA" });

            migrationBuilder.InsertData(
                table: "StatesDb",
                columns: new[] { "Id", "Description", "State" },
                values: new object[] { 3, "New York", "NY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatesDb",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatesDb",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatesDb",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
