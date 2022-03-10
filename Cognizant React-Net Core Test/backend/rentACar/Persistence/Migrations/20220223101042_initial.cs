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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<string>(type: "TEXT", nullable: false),
                    Longitude = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WarehouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    Make = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    YearModel = table.Column<short>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Licensed = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { 1, "47.13111", "-61.54801" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { 2, "15.95386", "7.06246" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { 3, "39.12788", "-2.71398" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { 4, "-70.84354", "132.22345" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "LocationId", "Name" },
                values: new object[] { 1, 1, "Warehouse A" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "LocationId", "Name" },
                values: new object[] { 2, 2, "Warehouse B" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "LocationId", "Name" },
                values: new object[] { 3, 3, "Warehouse C" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "LocationId", "Name" },
                values: new object[] { 4, 4, "Warehouse D" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Location", "WarehouseId" },
                values: new object[] { 1, "West wing", 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Location", "WarehouseId" },
                values: new object[] { 2, "East wing", 2 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Location", "WarehouseId" },
                values: new object[] { 3, "Suid wing", 3 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Location", "WarehouseId" },
                values: new object[] { 4, "Suid wing", 4 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 1, 1, new DateTime(2018, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Volkswagen", "Jetta III", 12947.52, (short)1995 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 2, 1, new DateTime(2018, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chevrolet", "Corvette", 20019.639999999999, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 3, 1, new DateTime(2018, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ford", "Expedition EL", 27323.419999999998, (short)2008 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 4, 1, new DateTime(2018, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Infiniti", "FX", 8541.6200000000008, (short)2010 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 5, 1, new DateTime(2018, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "GMC", "Safari", 14772.5, (short)1998 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 6, 1, new DateTime(2018, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Plymouth", "Colt Vista", 6642.4499999999998, (short)1994 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 7, 1, new DateTime(2018, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cadillac", "Escalade ESV", 24925.75, (short)2008 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 8, 1, new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mitsubishi", "Pajero", 28619.450000000001, (short)2002 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 9, 1, new DateTime(2017, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Infiniti", "Q", 6103.3999999999996, (short)1995 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 10, 1, new DateTime(2018, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ford", "Mustang", 18992.700000000001, (short)1993 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 11, 1, new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chevrolet", "G-Series 1500", 23362.41, (short)1997 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 12, 1, new DateTime(2018, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cadillac", "DeVille", 18371.529999999999, (short)1993 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 13, 1, new DateTime(2018, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Acura", "NSX", 23175.759999999998, (short)2001 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 14, 1, new DateTime(2018, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ford", "Econoline E250", 26605.540000000001, (short)1994 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 15, 1, new DateTime(2017, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lexus", "GX", 27395.259999999998, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 16, 1, new DateTime(2018, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dodge", "Ram Van 3500", 6244.5100000000002, (short)1999 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 17, 1, new DateTime(2017, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dodge", "Caravan", 16145.27, (short)1995 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 18, 1, new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dodge", "Dynasty", 15103.84, (short)1992 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 19, 1, new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dodge", "Ram 1500", 9977.6499999999996, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 20, 2, new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Maserati", "Coupe", 19957.709999999999, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 21, 2, new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Isuzu", "Rodeo", 6303.9899999999998, (short)1998 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 22, 2, new DateTime(2017, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Infiniti", "I", 6910.1599999999999, (short)2002 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 23, 2, new DateTime(2018, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Nissan", "Altima", 8252.6599999999999, (short)1994 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 24, 2, new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Toyota", "Corolla", 23732.110000000001, (short)2009 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 25, 2, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Acura", "MDX", 8487.1900000000005, (short)2011 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 26, 2, new DateTime(2017, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "BMW", "7 Series", 29069.52, (short)1998 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 27, 2, new DateTime(2018, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Nissan", "Maxima", 11187.68, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 28, 2, new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Audi", "A8", 16047.9, (short)1999 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 29, 2, new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Nissan", "Murano", 25859.779999999999, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 30, 2, new DateTime(2017, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Acura", "RL", 13232.129999999999, (short)2010 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 31, 2, new DateTime(2018, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mitsubishi", "Chariot", 15665.23, (short)1987 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 32, 2, new DateTime(2018, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "GMC", "3500 Club Coupe", 18129.369999999999, (short)1992 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 33, 2, new DateTime(2017, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dodge", "Dakota", 14479.370000000001, (short)2009 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 34, 2, new DateTime(2018, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mercury", "Grand Marquis", 20614.720000000001, (short)1996 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 35, 2, new DateTime(2018, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kia", "Sportage", 27106.470000000001, (short)2001 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 36, 2, new DateTime(2017, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chevrolet", "Blazer", 14835.48, (short)1994 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 37, 2, new DateTime(2018, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mercedes-Benz", "SL-Class", 27717.279999999999, (short)1994 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 38, 2, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Honda", "Civic Si", 18569.860000000001, (short)2003 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 39, 2, new DateTime(2018, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mercedes-Benz", "CL-Class", 23494.779999999999, (short)2002 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 40, 2, new DateTime(2018, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Volkswagen", "Jetta", 25469.490000000002, (short)2006 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 41, 2, new DateTime(2018, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pontiac", "Grand Prix", 11600.74, (short)1975 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 42, 2, new DateTime(2018, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Infiniti", "FX", 22000.619999999999, (short)2012 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 43, 2, new DateTime(2018, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jaguar", "XK", 10260.790000000001, (short)2006 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 44, 2, new DateTime(2018, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cadillac", "STS", 13740.200000000001, (short)2007 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 45, 2, new DateTime(2017, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Pontiac", "Sunfire", 28489.099999999999, (short)1997 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 46, 2, new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cadillac", "SRX", 26750.380000000001, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 47, 2, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Land Rover", "Freelander", 21770.59, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 48, 2, new DateTime(2018, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Suzuki", "Forenza", 28834.259999999998, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 49, 2, new DateTime(2018, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Saab", "9-7X", 25975.68, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 50, 2, new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ford", "Fusion", 28091.959999999999, (short)2012 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 51, 3, new DateTime(2018, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cadillac", "Escalade", 7429.1800000000003, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 52, 3, new DateTime(2017, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Porsche", "Cayenne", 17066.310000000001, (short)2011 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 53, 3, new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mercedes-Benz", "SL-Class", 14066.059999999999, (short)2005 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 54, 3, new DateTime(2018, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mitsubishi", "RVR", 22560.18, (short)1995 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 55, 3, new DateTime(2017, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Volvo", "850", 25762.080000000002, (short)1995 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 56, 3, new DateTime(2017, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Honda", "del Sol", 18840.959999999999, (short)1994 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 57, 3, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Infiniti", "Q", 28773.139999999999, (short)1996 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 58, 3, new DateTime(2018, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mercedes-Benz", "500E", 17141.080000000002, (short)1992 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 59, 3, new DateTime(2018, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "GMC", "Envoy XL", 18983.52, (short)2002 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 60, 3, new DateTime(2018, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Volkswagen", "Touareg 2", 15611.219999999999, (short)2008 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 61, 4, new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Saab", "900", 8771.0, (short)1987 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 62, 4, new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mazda", "B-Series", 23407.59, (short)1998 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 63, 4, new DateTime(2018, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "GMC", "Sierra 3500", 5869.2299999999996, (short)2012 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 64, 4, new DateTime(2018, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chevrolet", "Corvette", 16630.669999999998, (short)1964 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 65, 4, new DateTime(2018, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Toyota", "Tacoma", 11597.18, (short)1997 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 66, 4, new DateTime(2018, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "GMC", "Sonoma", 18248.209999999999, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 67, 4, new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bugatti", "Veyron", 8051.6400000000003, (short)2009 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 68, 4, new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dodge", "Ram 1500 Club", 14008.299999999999, (short)1996 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 69, 4, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Land Rover", "Discovery Series II", 18620.189999999999, (short)2001 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 70, 4, new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Volvo", "960", 7316.9300000000003, (short)1993 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 71, 4, new DateTime(2017, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chrysler", "LHS", 29444.709999999999, (short)2001 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 72, 4, new DateTime(2017, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Porsche", "944", 7396.9499999999998, (short)1984 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 73, 4, new DateTime(2017, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Subaru", "Legacy", 24491.799999999999, (short)2010 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 74, 4, new DateTime(2018, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Volvo", "XC90", 29009.650000000001, (short)2003 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 75, 4, new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Buick", "Skyhawk", 10567.27, (short)1985 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 76, 4, new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "GMC", "Envoy XUV", 20997.709999999999, (short)2004 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 77, 4, new DateTime(2018, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Volvo", "S60", 28614.950000000001, (short)2009 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 78, 4, new DateTime(2018, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Pontiac", "Montana", 11221.139999999999, (short)2000 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 79, 4, new DateTime(2018, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lexus", "RX", 23194.009999999998, (short)2002 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CarId", "DateAdded", "Licensed", "Make", "Model", "Price", "YearModel" },
                values: new object[] { 80, 4, new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lexus", "RX", 17805.450000000001, (short)2000 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_WarehouseId",
                table: "Cars",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarId",
                table: "Vehicles",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_LocationId",
                table: "Warehouses",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
