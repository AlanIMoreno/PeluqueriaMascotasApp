using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeluqueriaMascotasMVC.Migrations
{
    /// <inheritdoc />
    public partial class FixEmailColumnInPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Solución A: Agregar mapeo de Email a la tabla Personas
            // Esta migración SOLO corrige el error de "Invalid column name 'Email'"
            // Sin agregar Identity (eso viene después si lo necesitas)

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Personas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
