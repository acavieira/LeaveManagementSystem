using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRoleAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00f16303-fe25-4984-98cd-166fe0bb7dd1", null, "Administrator", "ADMINISTRATOR" },
                    { "5e6bab09-049c-4c6a-ba1f-df94de5362af", null, "Supervisor", "SUPERVISOR" },
                    { "9d46f036-5080-4ead-8613-94321d6aa8f3", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a2f3c4e5-6789-4b0c-9d1e-2f3a4b5c6d7e", 0, "08ba0817-9849-4512-b9af-7f4d820090e8", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEKBF7UFt6UBZm9kSeormmP25iOfbzP6sYNXxLDQI19EGHB7SLawoqQse+6xq5kMb8A==", null, false, "62363b04-0d7b-48ae-960c-fe3f2cc93d29", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00f16303-fe25-4984-98cd-166fe0bb7dd1", "a2f3c4e5-6789-4b0c-9d1e-2f3a4b5c6d7e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e6bab09-049c-4c6a-ba1f-df94de5362af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d46f036-5080-4ead-8613-94321d6aa8f3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00f16303-fe25-4984-98cd-166fe0bb7dd1", "a2f3c4e5-6789-4b0c-9d1e-2f3a4b5c6d7e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f16303-fe25-4984-98cd-166fe0bb7dd1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f3c4e5-6789-4b0c-9d1e-2f3a4b5c6d7e");
        }
    }
}
