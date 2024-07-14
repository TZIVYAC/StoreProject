using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MODELS.Migrations
{
    public partial class AddDonorIdToDonations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DonorId",
                table: "Donations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Donations");
        }
    }
}
