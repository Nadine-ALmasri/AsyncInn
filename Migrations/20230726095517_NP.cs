using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInnManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class NP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmenityId",
                table: "RoomAmenity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenityId",
                table: "RoomAmenity",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenities_AmenityId",
                table: "RoomAmenity",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Rooms_RoomID",
                table: "RoomAmenity",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenities_AmenityId",
                table: "RoomAmenity");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Rooms_RoomID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_AmenityId",
                table: "RoomAmenity");

            migrationBuilder.DropColumn(
                name: "AmenityId",
                table: "RoomAmenity");
        }
    }
}
