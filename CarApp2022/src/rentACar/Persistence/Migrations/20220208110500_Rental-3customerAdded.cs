using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Rental3customerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email" },
                values: new object[] { 1, "burakibrahim@gmail1.com" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email" },
                values: new object[] { 2, "burakibrahim@gmail2.com" });

            migrationBuilder.InsertData(
                table: "CorporateCustomers",
                columns: new[] { "Id", "CompanyName", "CustomerId", "TaxNo" },
                values: new object[,]
                {
                    { 1, "Burak Ünal", 2, "123321" },
                    { 2, "İbrahim Ünal", 1, "123321" }
                });

            migrationBuilder.InsertData(
                table: "IndividualCustomers",
                columns: new[] { "Id", "CustomerId", "FirstName", "LastName", "NationalIdentity" },
                values: new object[,]
                {
                    { 1, 2, "Burak", "Ünal", "3333333331" },
                    { 2, 1, "İbrahim", "Ünal", "1333333333" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CustomerId", "RentEndDate", "RentStartDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, 1, new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
