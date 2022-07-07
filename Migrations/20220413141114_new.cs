using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_CareHomes_CareHomeID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "CareHomeID",
                table: "Clients",
                newName: "CareHomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CareHomeID",
                table: "Clients",
                newName: "IX_Clients_CareHomeId");

            migrationBuilder.AlterColumn<int>(
                name: "CareHomeId",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_CareHomes_CareHomeId",
                table: "Clients",
                column: "CareHomeId",
                principalTable: "CareHomes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_CareHomes_CareHomeId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "CareHomeId",
                table: "Clients",
                newName: "CareHomeID");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CareHomeId",
                table: "Clients",
                newName: "IX_Clients_CareHomeID");

            migrationBuilder.AlterColumn<int>(
                name: "CareHomeID",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "HomeId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_CareHomes_CareHomeID",
                table: "Clients",
                column: "CareHomeID",
                principalTable: "CareHomes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
