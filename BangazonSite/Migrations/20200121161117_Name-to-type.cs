using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class Nametotype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaymentType");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PaymentType",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f86d83b5-2a7d-4316-886d-2e470e7e67ac", "AQAAAAEAACcQAAAAEMdoJZq7tYChnnH3C/LT8UwHAAgp6ZvjwnTFPg3IYs8YwcFUfX9iIbtOfSi7CAnD9g==" });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                column: "Type",
                value: "American Express");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                column: "Type",
                value: "Visa");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 3,
                column: "Type",
                value: "MasterCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PaymentType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaymentType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fceafd27-b662-448f-8a57-d49dcbe94185", "AQAAAAEAACcQAAAAEK8j3YSrp5K0gTbhq/MUEMLJYCGkOIbZbjvPJFnp1YtpSYwPCi4TBpS1WfgnD9yF1g==" });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                column: "Name",
                value: "American Express");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                column: "Name",
                value: "Visa");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 3,
                column: "Name",
                value: "MasterCard");
        }
    }
}
