using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labolatorium_3_8.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b78a9f98-a8d5-4ce4-b41b-c72449a6950d", "70d53541-9607-4ef7-9b3e-d1d8583c23be" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c64a0d38-3d8a-4f1d-82af-39f72c917f72", "762e0662-63f3-40dd-bbb8-8a512ccedd44" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78a9f98-a8d5-4ce4-b41b-c72449a6950d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c64a0d38-3d8a-4f1d-82af-39f72c917f72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70d53541-9607-4ef7-9b3e-d1d8583c23be");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "762e0662-63f3-40dd-bbb8-8a512ccedd44");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00c59fb7-0f52-4f62-9788-6e061abb8f81", "00c59fb7-0f52-4f62-9788-6e061abb8f81", "admin", "ADMIN" },
                    { "a4f6fb66-6cda-4506-b2ca-2e4972a02da3", "a4f6fb66-6cda-4506-b2ca-2e4972a02da3", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "41d2cf22-9879-490c-a39c-2c82cf351765", 0, "4def5de1-3e35-4e08-85e0-1d78d0b48589", "user@esei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEOZoy/EBtGTCLC60kWKhly5boBuii9FeBdU7Ey3m7Z0TW+fCOLvbTlDXSdc6PPOTEA==", null, false, "d42a792e-c3d0-4285-b17d-c83da9d37ceb", false, "user" },
                    { "8baedd9b-2b9a-48a4-8d30-556114195273", 0, "38c118ad-881d-4ca3-aa1f-2fc8d286cc11", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAEOXa3xN20r7WKCCvsBJabplmmHKVkLlB6G4hyK+1ZLDCTlnVcEG5nEP8/nl7k3JLdQ==", null, false, "f87dbe35-12f4-4042-b7a1-e8e69c4bc209", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 1, 27, 22, 42, 49, 294, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 1, 27, 22, 42, 49, 294, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a4f6fb66-6cda-4506-b2ca-2e4972a02da3", "41d2cf22-9879-490c-a39c-2c82cf351765" },
                    { "00c59fb7-0f52-4f62-9788-6e061abb8f81", "8baedd9b-2b9a-48a4-8d30-556114195273" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a4f6fb66-6cda-4506-b2ca-2e4972a02da3", "41d2cf22-9879-490c-a39c-2c82cf351765" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00c59fb7-0f52-4f62-9788-6e061abb8f81", "8baedd9b-2b9a-48a4-8d30-556114195273" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00c59fb7-0f52-4f62-9788-6e061abb8f81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4f6fb66-6cda-4506-b2ca-2e4972a02da3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d2cf22-9879-490c-a39c-2c82cf351765");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8baedd9b-2b9a-48a4-8d30-556114195273");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b78a9f98-a8d5-4ce4-b41b-c72449a6950d", "b78a9f98-a8d5-4ce4-b41b-c72449a6950d", "user", "USER" },
                    { "c64a0d38-3d8a-4f1d-82af-39f72c917f72", "c64a0d38-3d8a-4f1d-82af-39f72c917f72", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "70d53541-9607-4ef7-9b3e-d1d8583c23be", 0, "7ab06ac8-13ab-42a4-bf39-ed08e4ca8573", "user@esei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAIAAYagAAAAEFXqdpLCrhJsBo7eH/GoqtQCyjVP+u6FanJ5kFJ6AdwNSz7gfbtilJopTcNHbHgxFw==", null, false, "8beca7ec-62d3-4088-815b-060acb9e6120", false, "user" },
                    { "762e0662-63f3-40dd-bbb8-8a512ccedd44", 0, "e05fd0e8-a1c9-4e2c-beed-77f7f45640e2", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADMIN", "AQAAAAIAAYagAAAAEH8Eas6AWR0MwJsi8EECdVWHOuehIdrMGGlnl1tMGoeyXMXUMR28qYWjntaFGgFSaQ==", null, false, "ee79a4a3-983a-499c-ad87-852b9539eecd", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 1, 27, 21, 0, 50, 861, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 1, 27, 21, 0, 50, 861, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b78a9f98-a8d5-4ce4-b41b-c72449a6950d", "70d53541-9607-4ef7-9b3e-d1d8583c23be" },
                    { "c64a0d38-3d8a-4f1d-82af-39f72c917f72", "762e0662-63f3-40dd-bbb8-8a512ccedd44" }
                });
        }
    }
}
