using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductShop.Migrations
{
    /// <inheritdoc />
    public partial class MigrationEditeFieldNameCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PositionS_EmployeePosition",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionS",
                table: "PositionS");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeePosition",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EmployeePosition",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "PositionS",
                newName: "Positions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "PositionS");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeePosition",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionS",
                table: "PositionS",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeePosition",
                table: "Employees",
                column: "EmployeePosition");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PositionS_EmployeePosition",
                table: "Employees",
                column: "EmployeePosition",
                principalTable: "PositionS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
