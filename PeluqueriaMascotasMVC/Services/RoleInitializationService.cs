using Microsoft.AspNetCore.Identity;
using PeluqueriaMascotasMVC.Models;

namespace PeluqueriaMascotasMVC.Services
{
    public class RoleInitializationService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleInitializationService(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task InitializeRolesAsync()
        {
            // Definir roles disponibles
            var roles = new List<string>
            {
                "Admin",
                "Empleado",
                "Cliente"
            };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var roleDescription = role switch
                    {
                        "Admin" => "Administrador del sistema - Acceso completo",
                        "Empleado" => "Empleado de peluquería - Gestión de turnos y consultas",
                        "Cliente" => "Cliente - Acceso a compras y reserva de servicios",
                        _ => ""
                    };

                    var applicationRole = new ApplicationRole(role, roleDescription);
                    await _roleManager.CreateAsync(applicationRole);
                }
            }
        }
    }
}
