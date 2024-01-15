using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    /// <inheritdoc />
    public partial class vs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Order_tb_Account",
                table: "tb_Order");

            migrationBuilder.DropIndex(
                name: "IX_tb_Order_AccountID",
                table: "tb_Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_AccountID",
                table: "tb_Order",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Order_tb_Account",
                table: "tb_Order",
                column: "AccountID",
                principalTable: "tb_Account",
                principalColumn: "ID");
        }
    }
}
