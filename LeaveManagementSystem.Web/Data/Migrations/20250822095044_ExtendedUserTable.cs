using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DataOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f3c4e5-6789-4b0c-9d1e-2f3a4b5c6d7e",
                columns: new[] { "ConcurrencyStamp", "DataOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ac3f4fb-88b9-4854-9abc-f43d080b8743", new DateOnly(1990, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEKT+KsR7Tni8RCPn1bu5G2T5RfRAB3hITN4EsVCdSn5O9Q2Ag/tSPXjDKbYnNqaEsQ==", "222de61d-71d0-46ed-a928-c8e016928e0d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2f3c4e5-6789-4b0c-9d1e-2f3a4b5c6d7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08ba0817-9849-4512-b9af-7f4d820090e8", "AQAAAAIAAYagAAAAEKBF7UFt6UBZm9kSeormmP25iOfbzP6sYNXxLDQI19EGHB7SLawoqQse+6xq5kMb8A==", "62363b04-0d7b-48ae-960c-fe3f2cc93d29" });
        }
    }
}
