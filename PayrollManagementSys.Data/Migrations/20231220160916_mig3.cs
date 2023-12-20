using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollManagementSys.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c4a5e943-92ca-461b-851b-32d639563231");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0b99265a-3d14-4659-b5a0-c1228fd06959");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45ba9d08-2ba5-41c8-9566-e222abdbf406", "AQAAAAIAAYagAAAAEGRc/SPktBvKWAQsRyd0/tY1DoWlu1EZw5iEcgdgfLWhGzDTCbe+xj7Zh2mEu94nyQ==", "329a556b-6a7b-4a83-8662-b4100e7d047a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14266f8e-08d8-4712-9e3a-c3d00b583f8b", "AQAAAAIAAYagAAAAEEmpeYvaWn/thPq8GsWkb46HzCaR31KbSi4h06cONIsBn+41MIEo2yj+ttZcRCOw4A==", "f5023c5e-b9b5-4458-b530-39c6fc2c17db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3c87ffe5-f712-4beb-af51-ee2f56d9ac9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2c14ec98-fcf5-45b5-8032-c163c69129b0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonelId", "SecurityStamp" },
                values: new object[] { "0454cddf-5af9-4fab-9c08-c6c615fec34d", "AQAAAAIAAYagAAAAEG+cf1qylwCIH8jaItYZaWetqG4CKSx/pwG6iFzf6fdeNGP5YyyS0HWOE7qaRCy6YQ==", 0, "957c13f1-deaf-4457-9505-88312723b9c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonelId", "SecurityStamp" },
                values: new object[] { "64965a40-1ce1-40f1-9f0e-961ae0ea7406", "AQAAAAIAAYagAAAAEMllUlfjRHVEFM3Og/1cINYMxF3i9LqgBOBVh4GaxFnJgnURt3G7YeKtRFdlCoOOOw==", 0, "10bf0311-5f3f-44d1-90d6-b3332b28e82e" });
        }
    }
}
