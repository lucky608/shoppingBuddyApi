using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisaanCafeWebAPI.Migrations
{
    public partial class invoiceDetailsAddedwithnewUpdatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalAmount = table.Column<long>(type: "bigint", nullable: false),
                    ammountPaid = table.Column<long>(type: "bigint", nullable: false),
                    amountLeft = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceProductDetails_InvoiceDetails_Id",
                        column: x => x.Id,
                        principalTable: "InvoiceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceProductDetails_InvoiceDetails_InvoiceDetailsId",
                        column: x => x.InvoiceDetailsId,
                        principalTable: "InvoiceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProductDetails_InvoiceDetailsId",
                table: "InvoiceProductDetails",
                column: "InvoiceDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceProductDetails");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");
        }
    }
}
