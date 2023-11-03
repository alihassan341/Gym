using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym_Management_System.Migrations
{
    public partial class UpdatedEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Equipments");

            migrationBuilder.RenameColumn(
                name: "Equipment_Name",
                table: "Equipments",
                newName: "EquipmentName");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Equipments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Equipments");

            migrationBuilder.RenameColumn(
                name: "EquipmentName",
                table: "Equipments",
                newName: "Equipment_Name");

            migrationBuilder.AddColumn<long>(
                name: "Cost",
                table: "Equipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
