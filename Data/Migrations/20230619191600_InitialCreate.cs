using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtWebApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    State = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    State = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CommissionRate = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryID);
                });

            migrationBuilder.CreateTable(
                name: "Painting",
                columns: table => new
                {
                    PaintingID = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Painting", x => x.PaintingID);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.ShowID);
                    table.ForeignKey(
                        name: "FK_Show_Gallery_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "Gallery",
                        principalColumn: "GalleryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    WorkshopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopTitle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    WorkshopDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.WorkshopID);
                    table.ForeignKey(
                        name: "FK_Workshop_Gallery_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "Gallery",
                        principalColumn: "GalleryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowPainting",
                columns: table => new
                {
                    ShowPaintingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaintingID = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ShowID = table.Column<int>(type: "int", nullable: false),
                    Award = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowPainting", x => x.ShowPaintingID);
                    table.ForeignKey(
                        name: "FK_ShowPainting_Painting_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Painting",
                        principalColumn: "PaintingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowPainting_Show_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Show",
                        principalColumn: "ShowID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    WorkshopID = table.Column<int>(type: "int", nullable: true),
                    PaintingID = table.Column<string>(type: "nvarchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Painting_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Painting",
                        principalColumn: "PaintingID");
                    table.ForeignKey(
                        name: "FK_Product_Workshop_WorkshopID",
                        column: x => x.WorkshopID,
                        principalTable: "Workshop",
                        principalColumn: "WorkshopID");
                });

            migrationBuilder.CreateTable(
                name: "WorkshopRegisteration",
                columns: table => new
                {
                    WorkshopRegisterationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    WorkshopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopRegisteration", x => x.WorkshopRegisterationID);
                    table.ForeignKey(
                        name: "FK_WorkshopRegisteration_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopRegisteration_Workshop_WorkshopID",
                        column: x => x.WorkshopID,
                        principalTable: "Workshop",
                        principalColumn: "WorkshopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_PaintingID",
                table: "Product",
                column: "PaintingID",
                unique: true,
                filter: "[PaintingID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WorkshopID",
                table: "Product",
                column: "WorkshopID",
                unique: true,
                filter: "[WorkshopID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Show_GalleryID",
                table: "Show",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowPainting_PaintingID",
                table: "ShowPainting",
                column: "PaintingID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowPainting_ShowID",
                table: "ShowPainting",
                column: "ShowID");

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_GalleryID",
                table: "Workshop",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegisteration_CustomerID",
                table: "WorkshopRegisteration",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopRegisteration_WorkshopID",
                table: "WorkshopRegisteration",
                column: "WorkshopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShowPainting");

            migrationBuilder.DropTable(
                name: "WorkshopRegisteration");

            migrationBuilder.DropTable(
                name: "Painting");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Workshop");

            migrationBuilder.DropTable(
                name: "Gallery");
        }
    }
}
