using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class roleupd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d842653-9e37-40a0-83cf-20bd568feea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a82bae9-e10c-4cba-b07f-f93ca83d97f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bbc705b5-b60c-422c-95c5-4ac5f0d1fd27", null, "Employee", "EMPLOYEE" },
                    { "d03d2c0e-fccb-4b90-916b-2d3ac63e949f", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbc705b5-b60c-422c-95c5-4ac5f0d1fd27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d03d2c0e-fccb-4b90-916b-2d3ac63e949f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d842653-9e37-40a0-83cf-20bd568feea8", null, "Employee", "EMPLOYEE" },
                    { "7a82bae9-e10c-4cba-b07f-f93ca83d97f2", null, "Manager", "MANAGER" }
                });
        }
    }
}
