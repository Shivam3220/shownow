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
                    Coupon = table.Column<string>(type: "nvarchar(50)", nullable: true),
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


            migrationBuilder.InsertData(
        schema: "Shopnow",
        table: "Product",
        columns: new[] { "Uid", "Name", "Description", "Image", "Price", "Stock", "CreatedOn" },
        values: new object[,]
        {
            { Guid.NewGuid(), "Laptop", "High performance laptop", "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 1200.00m, 10, DateTime.UtcNow },
            { Guid.NewGuid(), "Smartphone", "Latest model smartphone", "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?q=80&w=1480&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 800.00m, 20, DateTime.UtcNow },
            { Guid.NewGuid(), "Headphones", "Noise cancelling headphones", "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", 150.00m, 50, DateTime.UtcNow }
        }
    );
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
