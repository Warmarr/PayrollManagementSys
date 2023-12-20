using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PayrollManagementSys.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "3c87ffe5-f712-4beb-af51-ee2f56d9ac9c", "Superadmin", "SUPERADMIN" },
                    { 2, "2c14ec98-fcf5-45b5-8032-c163c69129b0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Departmans",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "DenemeDepartman" },
                    { 2, false, "DenemeDepartman1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Addres", "BirtDate", "ConcurrencyStamp", "DepertmanId", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonelId", "PhoneNumber", "PhoneNumberConfirmed", "SGKNumara", "SecurityStamp", "StartedDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Kayseri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0454cddf-5af9-4fab-9c08-c6c615fec34d", 1, "superadmin@gmail.com", true, "Super", "Erkek", false, "Admin", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEG+cf1qylwCIH8jaItYZaWetqG4CKSx/pwG6iFzf6fdeNGP5YyyS0HWOE7qaRCy6YQ==", 0, "+905439999999", true, "123456", "957c13f1-deaf-4457-9505-88312723b9c9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "superadmin@gmail.com" },
                    { 2, 0, "Kayseri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "64965a40-1ce1-40f1-9f0e-961ae0ea7406", 2, "admin@gmail.com", true, "Admin", "Erkek", false, "Test", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMllUlfjRHVEFM3Og/1cINYMxF3i9LqgBOBVh4GaxFnJgnURt3G7YeKtRFdlCoOOOw==", 0, "+905439999988", true, "123457", "10bf0311-5f3f-44d1-90d6-b3332b28e82e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departmans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departmans",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
