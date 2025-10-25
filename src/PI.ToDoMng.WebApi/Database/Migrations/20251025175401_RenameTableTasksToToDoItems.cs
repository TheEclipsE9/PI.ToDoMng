using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PI.ToDoMng.WebApi.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableTasksToToDoItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("RENAME TABLE `Tasks` TO `ToDoItems`;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("RENAME TABLE `ToDoItems` TO `Tasks`;");
        }
    }
}
