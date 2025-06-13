using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolos2.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Anna", new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kowalska" },
                    { 2, "Jan", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Nurseries",
                columns: new[] { "NurseryID", "EstablishedDate", "Name" },
                values: new object[] { 1, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green Forest Nursery" });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "SpeciesId", "GrowthTimeInYears", "LatinName" },
                values: new object[] { 1, 10, "Latin" });

            migrationBuilder.InsertData(
                table: "SeedllingBatches",
                columns: new[] { "BatchId", "NurseryId", "Quantity", "ReadyDate", "SownDate", "SpeciesId" },
                values: new object[] { 1, 1, 10, new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Responsibles",
                columns: new[] { "BatchId", "EmployeeId", "Role" },
                values: new object[] { 1, 1, "Supervisor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responsibles",
                keyColumns: new[] { "BatchId", "EmployeeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SeedllingBatches",
                keyColumn: "BatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nurseries",
                keyColumn: "NurseryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trees",
                keyColumn: "SpeciesId",
                keyValue: 1);
        }
    }
}
