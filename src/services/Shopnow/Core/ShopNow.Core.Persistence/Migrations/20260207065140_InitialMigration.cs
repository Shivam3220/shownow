using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopNow.Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shopnow");

            migrationBuilder.CreateTable(
                name: "Cart",
                schema: "Shopnow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TotalItem = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coupon = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.UniqueConstraint("AK_Cart_Uid", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Shopnow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TotalItem = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coupon = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductMapping",
                schema: "Shopnow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalItem = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Shopnow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.UniqueConstraint("AK_Product_Uid", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Shopnow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartProductMapping",
                schema: "Shopnow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductFk = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalItem = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProductMapping_Cart_CartFk",
                        column: x => x.CartFk,
                        principalSchema: "Shopnow",
                        principalTable: "Cart",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProductMapping_Product_ProductFk",
                        column: x => x.ProductFk,
                        principalSchema: "Shopnow",
                        principalTable: "Product",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductMapping_CartFk",
                schema: "Shopnow",
                table: "CartProductMapping",
                column: "CartFk");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductMapping_ProductFk",
                schema: "Shopnow",
                table: "CartProductMapping",
                column: "ProductFk");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Shopnow",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProductMapping",
                schema: "Shopnow");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Shopnow");

            migrationBuilder.DropTable(
                name: "OrderProductMapping",
                schema: "Shopnow");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Shopnow");

            migrationBuilder.DropTable(
                name: "Cart",
                schema: "Shopnow");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Shopnow");
        }
    }
}
