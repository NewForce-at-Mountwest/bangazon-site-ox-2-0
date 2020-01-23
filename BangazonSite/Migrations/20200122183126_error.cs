using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_AspNetUsers_UserId",
                table: "PaymentType");

            migrationBuilder.AddColumn<string>(
                name: "Error",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PaymentType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f82177a5-82d8-4fcf-aa1c-4cd7924ada81", "AQAAAAEAACcQAAAAEI7Tv1f8Vs5wqaRfOMk9OGJus65sZ4680TmvEcCgQsj8nqqXpc0NESJpLBvE318Vcg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_AspNetUsers_UserId",
                table: "PaymentType",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_AspNetUsers_UserId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "Error",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PaymentType",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ca8238d-4d1a-4fc9-99a1-cc0588013309", "AQAAAAEAACcQAAAAEGlAzChu6uLKOF6iwlrjkkV922qgarnnXDHYObat/rdu/VcRn3x2hpccI8sVbQz8Bw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_AspNetUsers_UserId",
                table: "PaymentType",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
