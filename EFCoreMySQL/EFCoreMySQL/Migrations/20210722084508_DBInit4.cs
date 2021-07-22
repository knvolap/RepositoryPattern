using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMySQL.Migrations
{
    public partial class DBInit4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IDCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameCategory = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.IDCategory);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IDProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDCategory = table.Column<int>(type: "int", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MetaName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<float>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Status = table.Column<ulong>(type: "bit", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IDProduct);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IDCategory",
                        column: x => x.IDCategory,
                        principalTable: "Categories",
                        principalColumn: "IDCategory");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IDOder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDProduct = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(10)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    DayBuy = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Status = table.Column<ulong>(type: "bit", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IDOder);
                    table.ForeignKey(
                        name: "FK_Orders_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "IDProduct");
                });

            migrationBuilder.CreateIndex(
                name: "Idx_Description",
                table: "Categories",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "Idx_NameCategory",
                table: "Categories",
                column: "NameCategory");

            migrationBuilder.CreateIndex(
                name: "Idx_Supplier",
                table: "Categories",
                column: "Supplier");

            migrationBuilder.CreateIndex(
                name: "Idx_Address",
                table: "Orders",
                column: "Address");

            migrationBuilder.CreateIndex(
                name: "Idx_serName",
                table: "Orders",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IDProduct",
                table: "Orders",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "Idx_Author",
                table: "Products",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "Idx_NameProduct",
                table: "Products",
                column: "NameProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDCategory",
                table: "Products",
                column: "IDCategory");

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "UserGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_FirstName",
                table: "Users",
                column: "Account");

            migrationBuilder.CreateIndex(
                name: "Idx_LastName",
                table: "Users",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
