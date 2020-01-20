using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonSite.Migrations
{
    public partial class newdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fceafd27-b662-448f-8a57-d49dcbe94185", "AQAAAAEAACcQAAAAEK8j3YSrp5K0gTbhq/MUEMLJYCGkOIbZbjvPJFnp1YtpSYwPCi4TBpS1WfgnD9yF1g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "887202bb-967c-46ed-9429-335f52e89e63", "AQAAAAEAACcQAAAAEK1P2Fa7suuwaZss6lpDXtj8IxHUcgt8LDOgDeq0cJ1T+esxrMXOPF4g2A1wF9IXjA==" });
        }
    }
}
