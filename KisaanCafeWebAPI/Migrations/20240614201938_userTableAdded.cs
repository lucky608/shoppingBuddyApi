using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisaanCafeWebAPI.Migrations
{
    public partial class userTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceProductDetails_InvoiceDetails_InvoiceDetailsId",
                table: "InvoiceProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceProductDetails_InvoiceDetailsId",
                table: "InvoiceProductDetails");

            migrationBuilder.DropColumn(
                name: "ammountPaid",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "amountLeft",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropColumn(
                name: "size",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "status",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<long>(
                name: "ammountPaid",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "amountLeft",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProductDetails_InvoiceDetailsId",
                table: "InvoiceProductDetails",
                column: "InvoiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProductDetails_InvoiceDetails_InvoiceDetailsId",
                table: "InvoiceProductDetails",
                column: "InvoiceDetailsId",
                principalTable: "InvoiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
