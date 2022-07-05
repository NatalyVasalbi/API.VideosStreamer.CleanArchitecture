using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Data.Migrations
{
    public partial class RefactorimgColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Stremears_StreamerId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stremears",
                table: "Stremears");

            migrationBuilder.RenameTable(
                name: "Stremears",
                newName: "Streamers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streamers",
                table: "Streamers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos",
                column: "StreamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streamers",
                table: "Streamers");

            migrationBuilder.RenameTable(
                name: "Streamers",
                newName: "Stremears");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stremears",
                table: "Stremears",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Stremears_StreamerId",
                table: "Videos",
                column: "StreamerId",
                principalTable: "Stremears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
