using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "FindeksCreditRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindeksCreditRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FindeksCreditRates_Customers_CustomerId",
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
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(1109)),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalRentalDay = table.Column<short>(type: "smallint", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    RentalOfficeId = table.Column<int>(type: "int", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    MinFindeksCreditRate = table.Column<short>(type: "smallint", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_RentalOffices_RentalOfficeId",
                        column: x => x.RentalOfficeId,
                        principalTable: "RentalOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDamages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFixed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDamages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDamages_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    RentalStartOfficeId = table.Column<int>(type: "int", nullable: false),
                    RentalEndOfficeId = table.Column<int>(type: "int", nullable: true),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentalStartKilometer = table.Column<int>(type: "int", nullable: false),
                    RentalEndKilometer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rentals_RentalOffices_RentalEndOfficeId",
                        column: x => x.RentalEndOfficeId,
                        principalTable: "RentalOffices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rentals_RentalOffices_RentalStartOfficeId",
                        column: x => x.RentalStartOfficeId,
                        principalTable: "RentalOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Renault" },
                    { 2, "Honda" },
                    { 3, "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Black" },
                    { 3, "Blue" },
                    { 4, "Gray" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ContactEmail", "ContactNumber" },
                values: new object[,]
                {
                    { 1, "burakibrahim@gmail1.com", "123456789" },
                    { 2, "burakibrahim@gmail2.com", "223456781" },
                    { 3, "burakibrahim@gmail3.com", "323000789" },
                    { 4, "burakibrahim@gmail4.com", "423666781" }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Gasoline" }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "moderator" },
                    { 3, "user" }
                });

            migrationBuilder.InsertData(
                table: "RentalOffices",
                columns: new[] { "Id", "City", "OfficeName" },
                values: new object[,]
                {
                    { 1, 6, "Mamak" },
                    { 2, 6, "Kızlay" },
                    { 3, 35, "Gaziemir" },
                    { 4, 34, "Pendik" },
                    { 5, 6, "Tandoğan" }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manuel" },
                    { 2, "Auto" }
                });

            migrationBuilder.InsertData(
                table: "CorporateCustomers",
                columns: new[] { "Id", "CompanyName", "CompanyShortName", "CustomerId", "TaxNo" },
                values: new object[,]
                {
                    { 1, "CorporateCustomer1", "", 2, "1233213123" },
                    { 2, "CorporateCustomer2", "ab2", 1, "1233213214" }
                });

            migrationBuilder.InsertData(
                table: "FindeksCreditRates",
                columns: new[] { "Id", "CustomerId", "Score" },
                values: new object[,]
                {
                    { 2, 3, (short)1300 },
                    { 3, 1, (short)1150 },
                    { 4, 2, (short)1600 }
                });

            migrationBuilder.InsertData(
                table: "IndividualCustomers",
                columns: new[] { "Id", "CustomerId", "FirstName", "LastName", "NationalIdentity" },
                values: new object[,]
                {
                    { 1, 4, "IndividualCustomer1", "IndividualCustomer1", "3333333331" },
                    { 2, 3, "IndividualCustomer2", "IndividualCustomer2", "1333333333" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "RentalEndDate", "RentalPrice", "RentalStartDate", "SerialNumber", "TotalRentalDay" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5389), 1, new DateTime(2022, 2, 21, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5391), 10000m, new DateTime(2022, 2, 6, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5390), "1233210", (short)15 },
                    { 2, new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5422), 3, new DateTime(2022, 2, 13, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5424), 4500m, new DateTime(2022, 2, 10, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5423), "2233211", (short)9 },
                    { 3, new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5438), 2, new DateTime(2022, 2, 6, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5440), 3600m, new DateTime(2022, 1, 27, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5439), "3233212", (short)10 },
                    { 4, new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5455), 4, new DateTime(2022, 2, 13, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5457), 2900m, new DateTime(2022, 2, 10, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5455), "4233213", (short)9 }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "FuelId", "ImageUrl", "Name", "TransmissionId" },
                values: new object[,]
                {
                    { 1, 1, 500.0, 1, "", "Kangoo", 1 },
                    { 2, 1, 600.0, 1, "", "Clio", 1 },
                    { 3, 2, 1000.0, 2, "", "Civic", 1 },
                    { 4, 2, 1200.0, 2, "", "Civic", 2 },
                    { 5, 3, 1100.0, 1, "", "Corolla", 1 },
                    { 6, 3, 900.0, 2, "", "Yaris", 2 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "State", "City", "ColorId", "Kilometer", "MinFindeksCreditRate", "ModelId", "ModelYear", "Plate", "RentalOfficeId" },
                values: new object[,]
                {
                    { 1, 1, 6, 1, 100000, (short)1500, 1, (short)2005, "05avv03", 1 },
                    { 2, 1, 6, 2, 200000, (short)1300, 1, (short)2004, "05abb03", 2 },
                    { 3, 1, 34, 1, 300000, (short)1400, 1, (short)2006, "05acc03", 1 },
                    { 4, 1, 34, 3, 300000, (short)1400, 2, (short)2006, "05acd03", 3 }
                });

            migrationBuilder.InsertData(
                table: "CarDamages",
                columns: new[] { "Id", "CarId", "Description", "IsFixed" },
                values: new object[,]
                {
                    { 1, 1, "Engine Overheat", true },
                    { 2, 3, "Front panel broken", true },
                    { 3, 3, "Engine oil is changed", true }
                });

            migrationBuilder.InsertData(
                table: "CarDamages",
                columns: new[] { "Id", "CarId", "Description" },
                values: new object[] { 4, 2, "Brake pads changed" });

            migrationBuilder.InsertData(
                table: "Maintenances",
                columns: new[] { "Id", "CarId", "Description", "MaintenanceDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, "Findshield broken", new DateTime(2021, 11, 8, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5334), new DateTime(2021, 11, 28, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5335) },
                    { 2, 2, "Front hood rotten", new DateTime(2021, 12, 18, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5356), new DateTime(2021, 12, 21, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5357) },
                    { 3, 1, "engine overhear", new DateTime(2022, 1, 2, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5372), new DateTime(2022, 1, 22, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5373) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CustomerId", "RentalEndDate", "RentalEndKilometer", "RentalEndOfficeId", "RentalStartDate", "RentalStartKilometer", "RentalStartOfficeId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2022, 2, 21, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5194), 13400, 1, new DateTime(2022, 2, 6, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5184), 12300, 1, null },
                    { 2, 1, 3, new DateTime(2022, 2, 13, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5220), 57100, 1, new DateTime(2022, 2, 10, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5219), 54500, 2, new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5221) },
                    { 3, 3, 2, new DateTime(2022, 2, 6, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5240), 53400, 1, new DateTime(2022, 1, 27, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5239), 52300, 1, null },
                    { 4, 1, 4, new DateTime(2022, 2, 13, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5256), 41400, 1, new DateTime(2022, 2, 10, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5255), 39500, 2, new DateTime(2022, 2, 16, 10, 36, 55, 951, DateTimeKind.Local).AddTicks(5257) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDamages_CarId",
                table: "CarDamages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentalOfficeId",
                table: "Cars",
                column: "RentalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FindeksCreditRates_CustomerId",
                table: "FindeksCreditRates",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_CarId",
                table: "Maintenances",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_FuelId",
                table: "Models",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_TransmissionId",
                table: "Models",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalEndOfficeId",
                table: "Rentals",
                column: "RentalEndOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalStartOfficeId",
                table: "Rentals",
                column: "RentalStartOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDamages");

            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "FindeksCreditRates");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "RentalOffices");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Transmissions");
        }
    }
}
