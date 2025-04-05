using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crayon.TechExercise.CloudSales.DB.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftwareLicenseForeignKeyToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareLicense_Account_AccountId",
                table: "SoftwareLicense");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareLicense_AccountId",
                table: "SoftwareLicense");

            migrationBuilder.CreateIndex(
                name: "IX_Account_SoftwareLicenseId",
                table: "Account",
                column: "SoftwareLicenseId",
                unique: true,
                filter: "[SoftwareLicenseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_SoftwareLicense_SoftwareLicenseId",
                table: "Account",
                column: "SoftwareLicenseId",
                principalTable: "SoftwareLicense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_SoftwareLicense_SoftwareLicenseId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_SoftwareLicenseId",
                table: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicense_AccountId",
                table: "SoftwareLicense",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareLicense_Account_AccountId",
                table: "SoftwareLicense",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
