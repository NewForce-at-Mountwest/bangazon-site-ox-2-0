using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class builddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea090814-18e3-4f6f-ab99-9b511dc9a37b", "AQAAAAEAACcQAAAAEGxH90cFpLZZaAYKrRLlscEInRzMoxa4FrZKKcoR34Dz74a0cKLPqN+AEqtDWlrKkQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fceafd27-b662-448f-8a57-d49dcbe94185", "AQAAAAEAACcQAAAAEK8j3YSrp5K0gTbhq/MUEMLJYCGkOIbZbjvPJFnp1YtpSYwPCi4TBpS1WfgnD9yF1g==" });
        }
    }
}
