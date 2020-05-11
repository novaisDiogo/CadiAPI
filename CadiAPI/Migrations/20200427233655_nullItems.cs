using Microsoft.EntityFrameworkCore.Migrations;

namespace CadiAPI.Migrations
{
    public partial class nullItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Additionals_AdditionalId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Options_OptionsId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OptionsId",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalId",
                table: "OrderItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Additionals_AdditionalId",
                table: "OrderItems",
                column: "AdditionalId",
                principalTable: "Additionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Options_OptionsId",
                table: "OrderItems",
                column: "OptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Additionals_AdditionalId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Options_OptionsId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OptionsId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Additionals_AdditionalId",
                table: "OrderItems",
                column: "AdditionalId",
                principalTable: "Additionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Options_OptionsId",
                table: "OrderItems",
                column: "OptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
