using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Updating_TvSerie_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvSeries_Genders_GenderId",
                table: "TvSeries");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "TvSeries",
                newName: "SecondaryGenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TvSeries_GenderId",
                table: "TvSeries",
                newName: "IX_TvSeries_SecondaryGenderId");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryGenderId",
                table: "TvSeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeries_Genders_SecondaryGenderId",
                table: "TvSeries",
                column: "SecondaryGenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvSeries_Genders_SecondaryGenderId",
                table: "TvSeries");

            migrationBuilder.DropColumn(
                name: "PrimaryGenderId",
                table: "TvSeries");

            migrationBuilder.RenameColumn(
                name: "SecondaryGenderId",
                table: "TvSeries",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TvSeries_SecondaryGenderId",
                table: "TvSeries",
                newName: "IX_TvSeries_GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TvSeries_Genders_GenderId",
                table: "TvSeries",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
