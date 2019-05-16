using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Informations_PlaceId",
                table: "Informations",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Informations_Places_PlaceId",
                table: "Informations",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informations_Places_PlaceId",
                table: "Informations");

            migrationBuilder.DropIndex(
                name: "IX_Informations_PlaceId",
                table: "Informations");
        }
    }
}
