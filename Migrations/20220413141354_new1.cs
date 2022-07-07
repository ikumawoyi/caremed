using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_CareHomes_CareHomeId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Pharmacy_PharmacyID",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CareHomeId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_PharmacyID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PharmacyID",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PharmacyID",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareHomeID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pharmacy_CareHomes_CareHomeID",
                        column: x => x.CareHomeID,
                        principalTable: "CareHomes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CareHomeId",
                table: "Clients",
                column: "CareHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PharmacyID",
                table: "Clients",
                column: "PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_CareHomeID",
                table: "Pharmacy",
                column: "CareHomeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_CareHomes_CareHomeId",
                table: "Clients",
                column: "CareHomeId",
                principalTable: "CareHomes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Pharmacy_PharmacyID",
                table: "Clients",
                column: "PharmacyID",
                principalTable: "Pharmacy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
