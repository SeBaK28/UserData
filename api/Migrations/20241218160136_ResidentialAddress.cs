using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ResidentialAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfBirths_UserDatas_UserDataId",
                table: "PlaceOfBirths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceOfBirths",
                table: "PlaceOfBirths");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "PlaceOfBirths",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceOfBirths",
                table: "PlaceOfBirths",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ResidentialAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialAddress_UserDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfBirths_UserDataId",
                table: "PlaceOfBirths",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialAddress_UserDataId",
                table: "ResidentialAddress",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceOfBirths_UserDatas_UserDataId",
                table: "PlaceOfBirths",
                column: "UserDataId",
                principalTable: "UserDatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfBirths_UserDatas_UserDataId",
                table: "PlaceOfBirths");

            migrationBuilder.DropTable(
                name: "ResidentialAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceOfBirths",
                table: "PlaceOfBirths");

            migrationBuilder.DropIndex(
                name: "IX_PlaceOfBirths_UserDataId",
                table: "PlaceOfBirths");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlaceOfBirths");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "PlaceOfBirths",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceOfBirths",
                table: "PlaceOfBirths",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceOfBirths_UserDatas_UserDataId",
                table: "PlaceOfBirths",
                column: "UserDataId",
                principalTable: "UserDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
