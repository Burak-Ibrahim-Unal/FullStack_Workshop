using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initial : Migration
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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 17, 11, 12, 53, 16, DateTimeKind.Local).AddTicks(7807)),
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
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalOffices_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
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
                    FindexScore = table.Column<short>(type: "smallint", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
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
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Turkey" });

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
                table: "Provinces",
                columns: new[] { "Id", "Name", "CountryId" },
                values: new object[,]
                {
                    { 1, "Adana",1},
                    { 2, "Adıyaman",1},
                    { 3, "Afyonkarahisar",1},
                    { 4, "Ağrı",1},
                    { 5, "Amasya",1},
                    { 6, "Ankara",1},
                    { 7, "Antalya",1},
                    { 8, "Artvin",1},
                    { 9, "Aydın",1},
                    { 10, "Balıkesir",1},
                    { 11, "Bilecik",1},
                    { 12, "Bingöl",1},
                    { 13, "Bitlis",1},
                    { 14, "Bolu",1},
                    { 15, "Burdur",1},
                    { 16, "Bursa",1},
                    { 17, "Çanakkale",1},
                    { 18, "Çankırı",1},
                    { 19, "Çorum",1},
                    { 20, "Denizli",1},
                    { 21, "Diyarbakır",1},
                    { 22, "Edirne",1},
                    { 23, "Elazığ",1},
                    { 24, "Erzincan",1},
                    { 25, "Erzurum",1},
                    { 26, "Eskişehir",1},
                    { 27, "Gaziantep",1},
                    { 28, "Giresun",1},
                    { 29, "Gümüşhane",1},
                    { 30, "Hakkari",1},
                    { 31, "Hatay",1},
                    { 32, "Isparta",1},
                    { 33, "Mersin",1},
                    { 34, "İstanbul",1},
                    { 35, "İzmir",1},
                    { 36, "Kars",1},
                    { 37, "Kastamonu",1},
                    { 38, "Kayseri",1},
                    { 39, "Kırklareli",1},
                    { 40, "Kırşehir",1},
                    { 41, "Kocaeli",1},
                    { 42, "Konya",1},
                    { 43, "Kütahya",1},
                    { 44, "Malatya",1},
                    { 45, "Manisa",1},
                    { 46, "Kahramanmaraş",1},
                    { 47, "Mardin",1},
                    { 48, "Muğla",1},
                    { 49, "Muş",1},
                    { 50, "Nevşehir",1},
                    { 51, "Niğde",1},
                    { 52, "Ordu",1},
                    { 53, "Rize",1},
                    { 54, "Sakarya",1},
                    { 55, "Samsun",1},
                    { 56, "Siirt",1},
                    { 57, "Sinop",1},
                    { 58, "Sivas",1},
                    { 59, "Tekirdağ",1},
                    { 60, "Tokat",1},
                    { 61, "Trabzon",1},
                    { 62, "Tunceli",1},
                    { 63, "Şanlıurfa",1},
                    { 64, "Uşak",1},
                    { 65, "Van",1},
                    { 66, "Yozgat",1},
                    { 67, "Zonguldak",1},
                    { 68, "Aksaray",1},
                    { 69, "Bayburt",1},
                    { 70, "Karaman",1},
                    { 71, "Kırıkkale",1},
                    { 72, "Batman",1},
                    { 73, "Şırnak",1},
                    { 74, "Bartın",1},
                    { 75, "Ardahan",1},
                    { 76, "Iğdır",1},
                    { 77, "Yalova",1},
                    { 78, "Karabük",1},
                    { 79, "Kilis",1},
                    { 80, "Osmaniye",1},
                    { 81, "Düzce",1}
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
                table: "Districts",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Altındağ", 6 },
                    { 2, "Ayaş", 6 },
                    { 3, "Bala", 6 },
                    { 4, "Beypazarı", 6 },
                    { 5, "Çamlıdere", 6 },
                    { 6, "Çankaya", 6 },
                    { 7, "Çubuk", 6 },
                    { 8, "Elmadağ", 6 },
                    { 9, "Güdül", 6 },
                    { 10, "Kalecik", 6 },
                    { 11, "Kızılcahamam", 6 },
                    { 12, "Haymana", 6 },
                    { 13, "Nallıhan", 6 },
                    { 14, "Polatlı", 6 },
                    { 15, "Şereflikoçhisar", 6 },
                    { 16, "Yenimahalle", 6 },
                    { 17, "Gölbaşı", 6 },
                    { 18, "Keçiören", 6 },
                    { 19, "Mamak", 6 },
                    { 20, "Sincan", 6 },
                    { 21, "Kazan", 6 },
                    { 22, "Akyurt", 6 },
                    { 23, "Etimesgut", 6 },
                    { 24, "Evren", 6 },
                    { 25, "Pursaklar", 6 },
                    { 26, "Adalar", 34 },
                    { 27, "Bakırköy", 34 },
                    { 28, "Beşiktaş", 34 },
                    { 29, "Beykoz", 34 },
                    { 30, "Beyoğlu", 34 },
                    { 31, "Çatalca", 34 },
                    { 32, "Eyüp", 34 },
                    { 33, "Fatih", 34 },
                    { 34, "Gaziosmanpaşa", 34 },
                    { 35, "Kadıköy", 34 },
                    { 36, "Kartal", 34 },
                    { 37, "Sarıyer", 34 },
                    { 38, "Silivri", 34 },
                    { 39, "Şile", 34 },
                    { 40, "Şişli", 34 }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 41, "Üsküdar", 34 },
                    { 42, "Zeytinburnu", 34 },
                    { 43, "Büyükçekmece", 34 },
                    { 44, "Kağıthane", 34 },
                    { 45, "Küçükçekmece", 34 },
                    { 46, "Pendik", 34 },
                    { 47, "Ümraniye", 34 },
                    { 48, "Bayrampaşa", 34 },
                    { 49, "Avcılar", 34 },
                    { 50, "Bağcılar", 34 },
                    { 51, "Bahçelievler", 34 },
                    { 52, "Güngören", 34 },
                    { 53, "Maltepe", 34 },
                    { 54, "Sultanbeyli", 34 },
                    { 55, "Tuzla", 34 },
                    { 56, "Esenler", 34 },
                    { 57, "Arnavutköy", 34 },
                    { 58, "Ataşehir", 34 },
                    { 59, "Başakşehir", 34 },
                    { 60, "Beylikdüzü", 34 },
                    { 61, "Çekmeköy", 34 },
                    { 62, "Esenyurt", 34 },
                    { 63, "Sancaktepe", 34 },
                    { 64, "Sultangazi", 34 },
                    { 65, "Aliağa", 35 },
                    { 66, "Bayındır", 35 },
                    { 67, "Bergama", 35 },
                    { 68, "Bornova", 35 },
                    { 69, "Çeşme", 35 },
                    { 70, "Dikili", 35 },
                    { 71, "Foça", 35 },
                    { 72, "Karaburun", 35 },
                    { 73, "Karşıyaka", 35 },
                    { 74, "Kemalpaşa", 35 },
                    { 75, "Kınık", 35 },
                    { 76, "Kiraz", 35 },
                    { 77, "Menemen", 35 },
                    { 78, "Ödemiş", 35 },
                    { 79, "Seferihisar", 35 },
                    { 80, "Selçuk", 35 },
                    { 81, "Tire", 35 },
                    { 82, "Torbalı", 35 }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 83, "Urla", 35 },
                    { 84, "Beydağ", 35 },
                    { 85, "Buca", 35 },
                    { 86, "Menderes", 35 },
                    { 87, "Balçova", 35 },
                    { 88, "Çiğli", 35 },
                    { 89, "Gaziemir", 35 },
                    { 90, "Narlıdere", 35 },
                    { 91, "Güzelbahçe", 35 },
                    { 92, "Bayraklı", 35 },
                    { 93, "Karabağlar", 35 }
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
                    { 1, new DateTime(2022, 2, 17, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6320), 1, new DateTime(2022, 2, 22, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6322), 10000m, new DateTime(2022, 2, 7, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6321), "1233210", (short)15 },
                    { 2, new DateTime(2022, 2, 17, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6336), 3, new DateTime(2022, 2, 14, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6339), 4500m, new DateTime(2022, 2, 11, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6338), "2233211", (short)9 },
                    { 3, new DateTime(2022, 2, 17, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6348), 2, new DateTime(2022, 2, 7, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6349), 3600m, new DateTime(2022, 1, 28, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6349), "3233212", (short)10 },
                    { 4, new DateTime(2022, 2, 17, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6407), 4, new DateTime(2022, 2, 14, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6409), 2900m, new DateTime(2022, 2, 11, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6408), "4233213", (short)9 }
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
                table: "RentalOffices",
                columns: new[] { "Id", "DistrictId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 15 },
                    { 3, 25 },
                    { 4, 35 },
                    { 5, 45 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "State", "ColorId", "FindexScore", "Kilometer", "ModelId", "ModelYear", "Plate", "RentalOfficeId" },
                values: new object[,]
                {
                    { 1, 1, 1, (short)1500, 100000, 1, (short)2015, "05avv05", 1 },
                    { 2, 2, 2, (short)1300, 200000, 1, (short)2014, "05abb06", 2 },
                    { 3, 2, 1, (short)1400, 300000, 1, (short)2009, "05acc12", 1 },
                    { 4, 3, 3, (short)1400, 300000, 2, (short)2018, "05acd033", 3 },
                    { 5, 1, 4, (short)1450, 300000, 4, (short)2016, "05acd036", 4 }
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
                    { 1, 1, "Findshield broken", new DateTime(2021, 11, 9, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6278), new DateTime(2021, 11, 29, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6279) },
                    { 2, 2, "Front hood rotten", new DateTime(2021, 12, 19, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6292), new DateTime(2021, 12, 22, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6292) },
                    { 3, 1, "engine overhear", new DateTime(2022, 1, 3, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6301), new DateTime(2022, 1, 23, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6302) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CustomerId", "RentalEndDate", "RentalEndKilometer", "RentalEndOfficeId", "RentalStartDate", "RentalStartKilometer", "RentalStartOfficeId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2022, 2, 22, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6171), 13400, 1, new DateTime(2022, 2, 7, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6160), 12300, 1, null },
                    { 2, 1, 3, new DateTime(2022, 2, 14, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6192), 57100, 1, new DateTime(2022, 2, 11, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6191), 54500, 2, new DateTime(2022, 2, 17, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6193) },
                    { 3, 3, 2, new DateTime(2022, 2, 7, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6203), 53400, 1, new DateTime(2022, 1, 28, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6203), 52300, 1, null },
                    { 4, 1, 4, new DateTime(2022, 2, 14, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6214), 41400, 1, new DateTime(2022, 2, 11, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6213), 39500, 2, new DateTime(2022, 2, 17, 11, 12, 53, 17, DateTimeKind.Local).AddTicks(6215) }
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
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

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
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalOffices_DistrictId",
                table: "RentalOffices",
                column: "DistrictId");

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

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
