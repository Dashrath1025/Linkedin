using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkedIn.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JId",
                table: "jobOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_jobOffers_JId",
                table: "jobOffers",
                column: "JId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobOffers_jobCategories_JId",
                table: "jobOffers",
                column: "JId",
                principalTable: "jobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobOffers_jobCategories_JId",
                table: "jobOffers");

            migrationBuilder.DropIndex(
                name: "IX_jobOffers_JId",
                table: "jobOffers");

            migrationBuilder.DropColumn(
                name: "JId",
                table: "jobOffers");
        }
    }
}
