using Microsoft.EntityFrameworkCore.Migrations;

namespace UniClub.Infrastructure.Migrations
{
    public partial class Add_Club_MemberCount_ClubPeriod_IsPresent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "ClubPeriod",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MemberCount",
                table: "Club",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "ClubPeriod");

            migrationBuilder.DropColumn(
                name: "MemberCount",
                table: "Club");
        }
    }
}
