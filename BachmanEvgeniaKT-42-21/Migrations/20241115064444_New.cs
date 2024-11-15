using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BachmanEvgeniaKT_42_21.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeletionStatus",
                table: "cd_student",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletionStatus",
                table: "cd_student");
        }
    }
}
