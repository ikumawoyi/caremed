using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class care : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Tenant_TenantId",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_Medications_TenantId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Medications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Medications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medications_TenantId",
                table: "Medications",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Tenant_TenantId",
                table: "Medications",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
