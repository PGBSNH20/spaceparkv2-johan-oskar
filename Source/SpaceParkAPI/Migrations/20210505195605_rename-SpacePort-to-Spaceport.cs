using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class renameSpacePorttoSpaceport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_SpacePorts_SpacePortID",
                table: "Parkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpacePorts",
                table: "SpacePorts");

            migrationBuilder.RenameTable(
                name: "SpacePorts",
                newName: "Spaceports");

            migrationBuilder.RenameColumn(
                name: "SpacePortID",
                table: "Parkings",
                newName: "SpaceportID");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_SpacePortID",
                table: "Parkings",
                newName: "IX_Parkings_SpaceportID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spaceports",
                table: "Spaceports",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Spaceports_SpaceportID",
                table: "Parkings",
                column: "SpaceportID",
                principalTable: "Spaceports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Spaceports_SpaceportID",
                table: "Parkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spaceports",
                table: "Spaceports");

            migrationBuilder.RenameTable(
                name: "Spaceports",
                newName: "SpacePorts");

            migrationBuilder.RenameColumn(
                name: "SpaceportID",
                table: "Parkings",
                newName: "SpacePortID");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_SpaceportID",
                table: "Parkings",
                newName: "IX_Parkings_SpacePortID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpacePorts",
                table: "SpacePorts",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_SpacePorts_SpacePortID",
                table: "Parkings",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
