using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkedIn.Migrations
{
    public partial class dec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Mobile",
                table: "jobSeekers",
                type: "decimal(18,2)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Mobile",
                table: "jobSeekers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 10);
        }
    }
}
