using Microsoft.EntityFrameworkCore.Migrations;

namespace UniClub.Infrastructure.Migrations
{
    public partial class Remove_PK_ClubRoleId_MemberRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRole",
                table: "MemberRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRole",
                table: "MemberRole",
                columns: new[] { "MemberId", "ClubPeriodId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRole",
                table: "MemberRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRole",
                table: "MemberRole",
                columns: new[] { "MemberId", "ClubRoleId", "ClubPeriodId" });
        }
    }
}
