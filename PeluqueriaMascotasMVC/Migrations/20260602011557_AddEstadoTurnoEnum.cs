using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeluqueriaMascotasMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoTurnoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Pendiente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Turnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Pendiente",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }
    }
}
